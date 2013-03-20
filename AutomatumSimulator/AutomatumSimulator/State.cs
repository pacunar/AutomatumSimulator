#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

#endregion


/// <summary>
/// <remarks>
/// Clase que guarda la información de los estados creados
/// ya pertenezcan a AFD's o AFN's.
/// </remarks>
/// Un estado puede ser creado como un estado único o puede
/// ser creado como la unión de un conjunto de estados.
/// Entre la información guardada se encuentra:
/// <list type="bullet">
/// <item><term>Coordenadas x, y</term></item>
/// <item><term>label (etiqueta)</term></item>
/// <item><term>Color</term></item>
/// </list>
/// </summary>
[Serializable()]
public class State
{
    /// <summary>
    /// Color del estado creado, designado por el usuario.
    /// </summary>
    public Color color;
    /// <summary>
    /// Identificador único de este estado; este identificador es 
    /// dibujado dentro del circulo. 
    /// Cuando este estado es un conjunto de estados, este identificador 
    /// es el identificador del primer estado en el arreglo states.
    /// </summary>
    public String label;
    /// <summary>
    /// Coordenadas <i>x</i> y <i>y</i> que indican el lugar donde será
    /// dibujado el circulo que representa el estado. Esta coordenada indica la
    /// esquina superior izquierda de un rectángulo en el que el circulo esta circunscrito.
    /// </summary>
    public int x, y;
    /// <summary>
    /// Indica si este estado es un estado final (indicado por el usuario).
    /// </summary>
    public Boolean isFinal;
    /// <summary>
    /// Indica si este estado es el estado inicial del automatum.
    /// </summary>
    public Boolean isInitial;
    /// <summary>
    /// Indica si es el estado actual. Usado en la simulación, de tal manera que si
    /// este es el estado actual, se pone de un color azul.
    /// </summary>
    public Boolean isActualState = false;
    /// <summary>
    /// Indica si este objeto es o no un conjunto de estados;
    /// </summary>
    public Boolean esConjuntoDeEstados;
    /// <summary>
    /// Cuando es un conjunto de estados, en este arreglo se guardan
    /// todos los objetos <remarks>State</remarks> (esta misma clase)
    /// que pertenecen a dicho conjunto.
    /// </summary>
    public State[] states;

    /// <summary>
    /// Constructor de la clase cuando se desea crear un estado único.
    /// </summary>
    /// <param name="l">Etiqueta que va a identificar a este estado.</param>
    /// <param name="x">Coordenada x del estado.</param>
    /// <param name="y">Coordenada y del estado.</param>
    public State(String l, int x, int y)
    {
        label = l;
        this.x = x;
        this.y = y;
        esConjuntoDeEstados = false;
        color = Color.Black;
        isInitial = false;
    }

    /// <summary>
    /// Constructor de la clase cuando es un conjunto de estados.
    /// </summary>
    /// <param name="states2"><c>Hashtable</c> que incluye todos los objetos State
    /// que perteneceran al conjunto.</param>
    public State(Hashtable states2)
    {
        esConjuntoDeEstados = true;
        this.states = new State[states2.Count];
        label = "";
        int counter = 0;
        foreach (DictionaryEntry s in states2)
        {
            if ((((State)s.Value).isInitial) && (!isInitial))
                isInitial = true;
            this.states[counter] = (State)s.Value;
            if (counter == 0)
            {
                this.x = ((State)s.Value).x;
                this.y = ((State)s.Value).y;
                this.isFinal = ((State)s.Value).isFinal;
                this.color = ((State)s.Value).color;
            }
            counter++;
        }
        
        Boolean isChanged = true;
        while (isChanged) {
            isChanged = false;
            for (int i = 0; i < (states.Length-1); i++)
                    if (String.CompareOrdinal(((State)states[i]).label, ((State)states[i + 1]).label) > 0)
                    {
                        isChanged = true;
                        State toSwap = (State)states[i];
                        states[i] = states[i + 1];
                        states[i + 1] = toSwap;
                    }
        }
            for (int i = 0; i < states.Length; i++)
            {
                label += ((State)states[i]).label;
            }
    }

    /// <summary>
    /// Cuando es un conjunto de estados, devuelve el objeto State que se encuentra en 
    /// la posición <i>index</i> del arreglo states.
    /// </summary>
    /// <param name="index">Posición (índice) del arreglo states que se desea obtener.</param>
    /// <returns>Devuelve el objeto State del arreglo <i>[index].</i></returns>
    public State get(int index)
    {
        return states[index];
    }

    /// <summary>
    /// Revisa si este objeto contiene el estado con el identificador <i>key</i>.
    /// </summary>
    /// <param name="key">Identificador del estado que se desea verificar.</param>
    /// <returns>true si esta contenido.</returns>
    public Boolean contains(String key)
    {
        if (esConjuntoDeEstados)
        {
            Boolean toReturn = false;
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i].esConjuntoDeEstados)
                    toReturn = states[i].contains(key);
                if ( (states[i].label == key) && (!toReturn) )
                    return true;
            }
            return toReturn;
        } else 
            return (label == key);
    }

    /// <summary>
    /// Establece el estado como estado inicial del automatum.
    /// </summary>
    public void setAsInitial()
    {
        isInitial = true;
    }

    /// <summary>
    /// Borra del arreglo states un conjunto de estados.
    /// </summary>
    /// <param name="toRemove"><i>Hashtable</i> que contiene los estados a borrar</param>
    public void remove(Hashtable toRemove)
    {
        State[] newStates = new State[states.Length - toRemove.Count];
        int counter = 0;
        label = "";
        for (int i = 0; i < states.Length; i++)
            if (!toRemove.ContainsKey(states[i].label))
            {
                newStates[counter++] = states[i];
                label += states[i].label;
            }

        states = newStates;
        x = states[0].x;
        y = states[0].y;
    }
}
