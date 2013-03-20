#region Using directives

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;

#endregion


namespace AutomatumSimulator
{
    /// <summary>
    /// <remarks>
    /// Clase que guarda la información necesaria para modelar una linea.
    /// </remarks>
    /// Entre la información guardada se encuentra:
    /// <list type="bullet">
    /// <item><term>Estados origen y destino.</term></item>
    /// <item><term>Coordenadas del punto intermedio, para agregarle curvatura.</term></item>
    /// <item><term>Etiqueta, que indica el caracter de la transición.</term></item>
    /// </list>
    /// </summary>
    [Serializable()]
    public class Line
    {
        /// <summary>
        /// source indica el estado Origen de la linea.
        /// dest indica el estado Destino de la linea.
        /// Ambos son objetos de la clase State. <seealso cref="AutomatumSimulator.State.cs"/>
        /// </summary>
        public State source, dest;
        /// <summary>
        /// Coordenadas del punto intermedio. Este punto le agrega curvatura.
        /// </summary>
        public int intermediatePointX, intermediatePointY;
        /// <summary>
        /// Etiqueta que indica el caracter de la linea (transición). Será dibujado en el 
        /// punto intermedio.
        /// </summary>
        public String label;
        /// <summary>
        /// Indica si es la linea actual. Utilizado en la simulación, si la linea es la 
        /// actual entonces se dibuja con un color azul.
        /// </summary>
        public Boolean isActualLine = false;
        /// <summary>
        /// Color de la linea, ingresado por el usuario.
        /// </summary>
        public Color color;

        /// <summary>
        /// Constructor (y único método) de la clase. Se guarda toda la información en 
        /// los atributos.
        /// </summary>
        /// <param name="source">Estado origen. Objeto de la clase State.</param>
        /// <param name="dest">Estado destino. Objeto de la clase State.</param>
        /// <param name="xi">Coordenada x del punto intermedio.</param>
        /// <param name="yi">Coordenada y del punto intermedio.</param>
        public Line(State source, State dest, int xi, int yi) 
        {
            this.source = source;
            this.dest = dest;
            intermediatePointX = xi;
            intermediatePointY = yi;
            this.label = "";
            color = Color.Black;
        }
    }
}
