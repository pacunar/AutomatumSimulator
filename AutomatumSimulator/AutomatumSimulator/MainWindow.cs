#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;


#endregion

namespace AutomatumSimulator
{
    /// <summary>
    /// Ventana y clase principal del proyecto <remarks>AutomatumSimulator</remarks>. 
    /// Esta clase contiene los principales atributos y métodos utilizados para el correcto
    /// funcionamiento del sistema.
    /// A grandes rasgos, las tareas realizadas por AutomatumSimulator son:
    /// <list type="bullet">
    /// <item>
    /// <term>Modelación de AFD</term>
    /// <description>Permite modelar (dibujar) los distintos elementos
    /// de un Automatum Finito Determinístico.</description>
    /// </item>
    /// <item>
    /// <term>Representación matricial de un AFD</term>
    /// <description>Se puede observar la representación matricial de un automatum modelado.</description>
    /// </item>
    /// <item>
    /// <term>Simulación de AFD</term>
    /// <description>Luego de modelar un AFD, el sistema permite simular su funcionamiento 
    /// con una cuerda de caracteres ingresada por el usuario. La simulación es realizada 
    /// con ayuda de colores y ventanas que describen su comportamiento </description>
    /// </item>
    /// <item>
    /// <term>Minimización de AFD</term>
    /// <description>Luego de tener un AFD modelado, se puede obtener un AFD mínimo (óptimo) 
    /// utilizando dos tipos de algoritmos: Bottom-Up y Top-Down.</description>
    /// </item>
    /// <item>
    /// <term>Modelación de AFN</term>
    /// <description>El sistema permite tambien modelar (dibujar) AFN, permitiendo varias transiciones de 
    /// un mismo estado con el mismo caracter o con la cuerda nula.</description>
    /// </item>
    /// <item>
    /// <term>Representación matricial de un AFN</term>
    /// <description>De la misma manera que los AFD, los AFN también pueden ser representados
    /// en su forma matricial.</description>
    /// </item>
    /// <item>
    /// <term>Simulación de AFN</term>
    /// <description>Se permite la simulación del comportamiento de un AFN tomando una cuerda ingresada 
    /// por el usuario; cuando existen varias opciones de transición, la simulación es interrumpida y se 
    /// le pide al usuario que decida el <i>camino</i> a tomar.</description>
    /// </item>
    /// <item>
    /// <term>Conversión AFN -> AFD</term>
    /// <description>Los AFN creados pueden convertirse en AFD mediante una implementación 
    /// del algoritmo de Thompson en el sistema. Al AFD resultante se le pueden aplicar 
    /// todas las operaciones anteriormente mencionadas.</description>
    /// </item>
    /// </list>
    /// </summary>
    partial class MainWindow : Form
    {
        /// <summary>Contador de los estados creados.</summary>
        public int counterstates = -1;
        /// <summary>Atributo booleano que indica si fue presionado el boton de estados.</summary>
        public Boolean statesclicked = false;
        /// <summary>Atributo booleano que indica si fue presionado el boton de lineas.</summary>
        public Boolean linesclicked = false;
        /// <summary>Atributo booleano que indica que un estado fue presionado inicialmente.</summary>
        public Boolean firstStateClicked = false;
        /// <summary>Guarda el identificador del estado inicialmente presionado.</summary>
        public String firstState;
        /// <summary>Atributo booleano que indica si fue presionado el boton de borrar.</summary>
        public Boolean deleteclicked = false;
        /// <summary>Atributo booleano que indica si fue presionado el boton de animar.</summary>
        public Boolean animateclicked = false;
        /// <summary>Atributo booleano que indica si fue presionado el boton de minimizar.</summary>
        public Boolean minimizaclicked = false;
        /// <summary>Atributo booleano que indica si fue presionado el boton de minimizar, 
        /// algoritmo Top-Down.</summary>
        public Boolean minimizaTDclicked = false;
        /// <summary>Atributo booleano que indica si fue presionado el boton de minimizar, 
        /// algoritmo Bottom-Up.</summary>
        public Boolean minimizaBUclicked = false;
        /// <summary>Atributo booleano que indica que un boton fue presionado.</summary>
        public Boolean buttonclicked = false;
        /// <summary>Atributo booleano que indica que un punto intermedio (utilizado para la creacion de lineas) 
        /// ha sido presionado.</summary>
        public Boolean intermediatePointclicked = false;
        /// <summary>Guarda la información del punto intermedio utilizado en la creación de lineas.</summary>
        public Point intermediatePoint = new Point();
        /// <summary>Hashtable que guarda todos los estados que forman parte del automatum AFD.
        /// En las llaves es guardado el identificador, y en el valor es guardado el objeto
        /// de la clase State.</summary>
        public Hashtable estados = new Hashtable();
        /// <summary>Hashtable que guarda todas las lineas que forman parte del automatum AFD.
        /// En las llaves es guardado el identificador de la linea (caracter), y en el valor
        /// es guardado el objeto de la clase Line.</summary>
        public Hashtable lineas = new Hashtable();
        /// <summary>Hashtable que guarda todas las transiciones del automatum AFD.
        /// En las llaves es guardada la concatenación del estado origen y el caracter 
        /// que define la transición, y en el valor es guardado el identificador del estado destino
        /// </summary>
        public Hashtable automata = new Hashtable();
        /// <summary>Hashtables utilizadas para guardar información de automata AFD creados y que fueron
        /// modificados.</summary>
        private Hashtable oldestados, oldlineas, oldautomata;
        /// <summary>Objetos de la clase Graphics, utilizados para que se permite dibujar en un panel.
        /// g es el objeto para el panel de AFD. g2 es el objeto para la representación matricial de AFD.
        /// </summary>
        Graphics g, g2;
        /// <summary>Objetos de la clase Graphics, utilizados para que se permite dibujar en un panel.
        /// g es el objeto para el panel de AFN. g2 es el objeto para la representación matricial de AFN.
        /// </summary>
        Graphics gafn, gafn2;
        /// <summary>Cursor inicial.</summary>
        public Cursor inicial;
        /// <summary>Identificador del estado inicial del automatum AFD.</summary>
        public String InitialState = "";
        /// <summary>Identificador del estado actual, utilizado en la simulación.</summary>
        private String actualState = "";
        /// <summary>Cuerda de caracteres ingresada por el usuario cuando se desea simular el automatum.</summary>
        private String textInput = "";
        /// <summary>El número de caracteres que tiene la cuerda ingresada por el usuario.</summary>
        private int textInputCounter = 0;
        /// <summary>Nombre del archivo a guardar o a abrir.</summary>
        private String fileName;
        
        /// <summary>
        /// Constructor. Inicializa los componentes de la ventana principal.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            panel2.AutoScrollMinSize = new Size(876, 586);
            afnmatricial.AutoScrollMinSize = new Size(876, 586);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            g = afdDraw.CreateGraphics();
            g2 = panel2.CreateGraphics();
            gafn = afnDraw.CreateGraphics();
            States.Select();
            inicial = afdDraw.Cursor;
        }

        /// <summary>
        /// Metodo que dibuja el Automatum AFD en forma gráfica. 
        /// Se recorren las tablas que guardan los estados y las lineas y se van dibujando segun 
        /// la información guardada en esos objetos. 
        /// Para dibujar los estados se utiliza el metodo drawEllipse y se escribe su identificador.
        /// Para dibujar las lineas se utiliza el metodo drawCurve, utilizando los puntos 
        /// medios de los estados origen y destino dependiendo de su posición y dirección; las curvas son 
        /// dibujadas de tal manera que a la punta "final" se le dibuje una punta de flecha, esto es realizado
        /// con la clase AdjustableArrowCap.
        /// Tambien se revisan atributos de los estados creados, como si son estados finales o iniciales.
        /// Minimización:
        /// <para>
        /// En los algoritmos de minimización, se van guardando las etapas de la minimización en arreglos que 
        /// contienen las Hashtable estados, lineas y automata, por lo que en este metodo se revisa si
        /// existen las etapas de minimización y en que étapa se encuentra, para dibujar la etapa elegida por
        /// el usuario.
        /// </para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afdDraw_Paint(object sender, PaintEventArgs e)
        {
            if (minimizaclicked)
            {
                States.Enabled = Lineas.Enabled = delete.Enabled = clear.Enabled = Animate.Enabled = false;
                if (etapasCounterTD == 0)
                {
                    topleft.Enabled = left.Enabled = false;
                    topright.Enabled = right.Enabled = true;
                    cerrar.Enabled = true;
                }
                else
                {
                    if (etapasCounterTD == (etapasMinimizacionTD.Count - 1))
                    {
                        topleft.Enabled = left.Enabled = true;
                        topright.Enabled = right.Enabled = false;
                        cerrar.Enabled = true;
                    }
                    else
                    {
                        topleft.Enabled = left.Enabled = topright.Enabled = right.Enabled = true;
                        cerrar.Enabled = false;
                    }
                }


                Hashtable paraActualizar = (Hashtable)etapasMinimizacionTD[etapasCounterTD];
                estados = (Hashtable)paraActualizar["estados"];
                lineas = (Hashtable)paraActualizar["lineas"];
                automata = (Hashtable)paraActualizar["automata"];

                if (automata.Count == 0)
                    Animate.Enabled = false;
                else
                    Animate.Enabled = true;

                explicacion.Text = (String)etapasMinimizacionExplicacionTD[etapasCounterTD];

            }
            Pen pencil = new Pen(Color.Black, 2);
            AdjustableArrowCap aac = new AdjustableArrowCap(5, 5, true);
            pencil.CustomEndCap = aac;
            Font font = new Font("Arial", 10);
            SolidBrush brush = new SolidBrush(Color.Black);
            foreach (DictionaryEntry de in estados)
            {
                State s = (State)de.Value;
                pencil.Color = s.color;
                brush.Color = s.color;
                if (s.isActualState)
                    pencil.Color = Color.Blue;
                if (s.isFinal)
                {
                    pencil.Width = 3;
                    g.DrawEllipse(pencil, s.x -4, s.y - 4, 38, 38);
                    pencil.Width = 2;
                    g.DrawEllipse(pencil, s.x, s.y, 30, 30);
                }
                else
                    g.DrawEllipse(pencil, s.x, s.y, 30, 30);
                g.DrawString(s.label, font, brush, (s.x + 5), (s.y + 8));
                if (s.isInitial)
                {
                    Point[] p = new Point[3];
                    p[2].X = s.x;
                    p[2].Y = s.y + 15;
                    p[1].X = s.x - 15;
                    p[1].Y = s.y;
                    p[0].X = s.x - 30;
                    p[0].Y = s.y - 5;
                    g.DrawCurve(pencil, p);
                }
            }
            foreach (DictionaryEntry de in lineas)
            {
                Line l = (Line)de.Value;
                Point[] p = new Point[3];
                pencil.Color = l.color;
                brush.Color = l.color;
                int dxSource = l.intermediatePointX - l.source.x;
                int dxDest = l.intermediatePointX - l.dest.x;
                int dySource = l.intermediatePointY - l.source.y;
                int dyDest = l.intermediatePointY - l.dest.y;
                p[1] = new Point(l.intermediatePointX, l.intermediatePointY);
                if (Math.Abs(dxSource) < Math.Abs(dySource))
                    if (dySource > 0)
                        p[0] = new Point((l.source.x + 15), (l.source.y + 30));
                    else
                        p[0] = new Point((l.source.x + 15), l.source.y);
                else
                    if (dxSource > 0)
                    p[0] = new Point((l.source.x + 30), (l.source.y + 15));
                else
                    p[0] = new Point(l.source.x, l.source.y + 15);

                if (Math.Abs(dxDest) < Math.Abs(dyDest))
                    if (dyDest > 0)
                        p[2] = new Point((l.dest.x + 15), (l.dest.y + 30));
                    else
                        p[2] = new Point((l.dest.x + 15), l.dest.y);
                else
                    if (dxDest > 0)
                    p[2] = new Point((l.dest.x + 30), (l.dest.y + 15));
                else
                    p[2] = new Point(l.dest.x, (l.dest.y + 15));

                if (l.source.label == l.dest.label)
                {
                    if (l.intermediatePointX < l.source.x)
                        if (l.intermediatePointY < l.source.y)
                        {
                            p[0] = new Point(l.source.x, l.source.y + 15);
                            p[2] = new Point(l.dest.x + 15, l.dest.y);
                        }
                        else
                        {
                            p[0] = new Point(l.source.x, l.source.y + 15);
                            p[2] = new Point(l.dest.x + 15, l.dest.y + 30);
                        }
                    if (l.intermediatePointX > l.source.x)
                        if (l.intermediatePointY < l.source.y)
                        {
                            p[0] = new Point(l.source.x + 30, l.source.y + 15);
                            p[2] = new Point(l.dest.x + 15, l.dest.y);
                        }
                        else
                        {
                            p[0] = new Point(l.source.x + 30, l.source.y + 15);
                            p[2] = new Point(l.dest.x + 15, l.dest.y + 30);
                        }
                }

                if (l.isActualLine)
                    pencil.Color = Color.Blue;
                g.DrawCurve(pencil, p);
                Font f = new Font("Arial", 10, FontStyle.Bold);
                g.DrawString(l.label, f, brush, p[1].X - 15, p[1].Y - 15);
            }
        }

        /// <summary>
        /// Metodo llamado cuando es presionado el panel donde se dibuja los automata AFD.
        /// Este método obtiene la posición (coordenada) exacta donde se presionó el mouse y 
        /// se revisa si se habia presionado algún botón de edición del automatum.
        /// Si se presionó el botón izquierdo del mouse, y el botón de estados fue presionado anteriormente, 
        /// entonces se procede a crear un estado nuevo (un objeto nuevo de la clase State) donde se le pide 
        /// al usuario ingresar los datos requeridos para la correcta creación de estados.
        /// Si se presionó el botón de lineas, entonces este método es llamado 3 veces:
        /// la primera vez que se presiona el mouse se guarda el primer estado (que sera estado origen);
        /// la seguna vez que se presiona el mouse, se guarda el punto intermedio que le agregara curvatura
        /// a la curva; y la tercera vez que se presiona el mouse se guarda el estado destino de la curva.
        /// Con estos datos la linea puede ser creada luego que se le pregunta al usuario los datos 
        /// necesarios para la correcta creación de las lineas.
        /// Si se presionó el botón de borrar, entonces se revisa si se presionó sobre un estado y si
        /// el botón del mouse presionado fue el derecho, se le pregunta al usuario que desea realizar 
        /// y dependiendo de esto se borra o no el estado. En cambio, si el botón del mouse presionado
        /// fue el derecho, entonces se espera que el usuario presione los dos estados (origen y destino) 
        /// en la dirección correcta para preguntarle al usuario si desea borrar la linea. Si existieran 
        /// mas de una linea entre esos dos estados en esa misma direccion, se le pregunta al usuario 
        /// el caracter que define la linea que desea borrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afdDraw_Click(object sender, EventArgs e)
        {
            int x = ((MouseEventArgs)e).X;
            int y = ((MouseEventArgs)e).Y;
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
                rightClick(x, y);
            if (buttonclicked)
            {
                if (statesclicked)
                {
                    buttonclicked = statesclicked = false;
                    Lineas.Enabled = delete.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = true;
                    State s = new State("S" + (++counterstates), x, y);
                    while (estados.ContainsKey("S" + counterstates))
                        counterstates++;
                    estados.Add("S" + counterstates, s);
                    saveToolStripMenuItem.Enabled = true;
                    afdDraw.Refresh();
                    dialog d = new dialog("Enter the new state name", "S" + counterstates, false, Color.Black);
                    d.ShowDialog(this);
                    if (d.isCorrect)
                    {
                        s.label = d.text;
                        s.isFinal = d.isFinal;
                        s.color = d.color;
                    }
                    else
                    {
                        estados.Remove("S" + counterstates);
                        counterstates--;
                        goto finstatesclicked;
                    }
                    try
                    {
                        estados.Remove("S" + counterstates);
                        if (InitialState == "")
                        {
                            InitialState = s.label;
                            s.isInitial = true;
                        }
                        estados.Add(s.label, s);
                    }
                    catch (Exception)
                    {
                        counterstates--;
                        State toReplace = (State)estados[s.label];
                        estados.Remove(s.label);
                        //toReplace.x = x;
                        //toReplace.y = y;
                        s.isInitial = toReplace.isInitial;
                        estados.Add(s.label, s);
                        Boolean[] toUpdateBoolean = new Boolean[lineas.Count];
                        String[] toUpdate = new String[lineas.Count];
                        int counter = 0;
                        foreach (DictionaryEntry de in lineas)
                        {
                            String[] toCheck = breakKey((String)de.Key);
                            if (toCheck[0] == s.label)
                            {
                                toUpdate[counter] = (String)de.Key;
                                toUpdateBoolean[counter++] = true;
                            }
                        }
                        foreach (DictionaryEntry de2 in automata)
                        {
                            String[] toCheck = breakKey((String)de2.Key);
                            if (((String)de2.Value) == s.label)
                            {
                                toUpdate[counter] = (String)de2.Key;
                                toUpdateBoolean[counter++] = false;
                            }
                        }
                        for (int i = 0; i < counter; i++)
                        {
                            Line l = (Line)lineas[toUpdate[i]];
                            lineas.Remove(toUpdate[i]);
                            if (toUpdateBoolean[i])
                            {
                                l.source.x = x;
                                l.source.y = y;
                            }
                            else
                            {
                                l.dest.x = x;
                                l.dest.y = y;
                            }
                            lineas.Add(toUpdate[i], l);
                        }
                    }
                finstatesclicked: afdDraw.Cursor = inicial;
                    afdDraw.Refresh();
                }
                if (linesclicked)
                {
                    String index = clickedOnAState(x, y);
                    if (index != null)
                    {
                        if (!firstStateClicked)
                        {
                            firstStateClicked = true;
                            firstState = index;
                        }
                        else
                        {
                            if (intermediatePointclicked)
                            {
                                Line l = new Line((State)estados[firstState], (State)estados[index], intermediatePoint.X, intermediatePoint.Y);
                                l.label = "";
                                lineas.Add(firstState + ":", l);
                                afdDraw.Refresh();
                                dialogLine d = new dialogLine("Enter the character of the arc", true, true);
                                d.ShowDialog(this);
                                if (d.isCorrect)
                                {
                                    l.label = d.text;
                                    l.color = d.color;
                                    lineas.Remove(firstState + ":");
                                    String key = firstState + ":" + d.text;
                                    try
                                    {
                                        lineas.Add(key, l);
                                    }
                                    catch (ArgumentException)
                                    {
                                        lineas.Remove(key);
                                        lineas.Add(key, l);
                                    }
                                    try
                                    {
                                        automata.Add(key, index);
                                    }
                                    catch (ArgumentException)
                                    {
                                        automata.Remove(key);
                                        automata.Add(key, index);
                                    }
                                }
                                else
                                    lineas.Remove(firstState + ":");
                                saveToolStripMenuItem.Enabled = true;
                                firstStateClicked = intermediatePointclicked = false;
                                intermediatePoint.X = intermediatePoint.Y = 0;
                                firstState = null;
                                States.Enabled = delete.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = true;
                                linesclicked = false;
                                afdDraw.Refresh();
                            }
                        }
                    }
                    else
                    {
                        if (!intermediatePointclicked)
                        {
                            intermediatePointclicked = true;
                            intermediatePoint.X = x;
                            intermediatePoint.Y = y;
                        }
                    }
                }

                if (deleteclicked)
                {
                    String index = clickedOnAState(x, y);
                    if (index != null)
                    {
                        if (!firstStateClicked)
                        {
                            firstStateClicked = true;
                            firstState = index;
                        }
                        else
                        {
                            String caption = "Delete line?";
                            String message = "Are you sure you want to delete the line?";
                            String[] toRemove = new String[lineas.Count];
                            int counter = 0;
                            foreach (DictionaryEntry de in lineas)
                            {
                                String[] toCheck = breakKey((String)de.Key);
                                if (toCheck[0] == firstState)
                                    toRemove[counter++] = (String)de.Key;
                            }
                            if (counter > 1)
                            {
                                dialogLine d = new dialogLine("Enter the character of the line to erase", false, false);
                                d.ShowDialog(this);
                                if (d.isCorrect)
                                {
                                    for (int i = 0; i < counter; i++)
                                    {
                                        if ((firstState + ":" + d.text) == toRemove[i])
                                        {
                                            DialogResult result = MessageBox.Show(this, message, caption, MessageBoxButtons.OKCancel);
                                            if (result == DialogResult.Cancel)
                                                goto finborrarlineas;
                                            lineas.Remove(toRemove[i]);
                                            automata.Remove(toRemove[i]);
                                        }
                                    }
                                }
                            }
                            else
                                if (counter == 1)
                            {
                                DialogResult result = MessageBox.Show(this, message, caption, MessageBoxButtons.OKCancel);
                                if (result == DialogResult.Cancel)
                                    goto finborrarlineas;
                                lineas.Remove(toRemove[0]);
                                automata.Remove(toRemove[0]);
                            }
                        finborrarlineas: afdDraw.Refresh();
                            saveToolStripMenuItem.Enabled = true;
                            firstStateClicked = false;
                            firstState = null;
                            States.Enabled = delete.Enabled = Animate.Enabled = minimiza.Enabled = Lineas.Enabled = clear.Enabled = true;
                            linesclicked = false;
                            deleteclicked = false;
                            afdDraw.Cursor = inicial;
                        }
                    }
                }

                /*if (animateclicked)

                if (resetclicked)
*/
            }
        }

        /// <summary>
        /// Metodo llamado cuando se presiona doble-click del mouse sobre el panel grafico de los AFD.
        /// Este método revisa si se presionó sobre un estado, de ser asi una ventana se levanta
        /// para permitir al usuario editar los valores de un estado creado anteriormente.
        /// Esto último se realiza dibujando otro estado en la posición deseada e ingresandole 
        /// como identificador al identificador único del estado que se desea mover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afdDraw_DoubleClick(object sender, EventArgs e)
        {
            int x = ((MouseEventArgs)e).X;
            int y = ((MouseEventArgs)e).Y;
            String index = clickedOnAState(x, y);
            if (index != null)
            {
                String oldlabel = ((State)estados[index]).label;
                Boolean oldisFinal = ((State)estados[index]).isFinal;
                Color oldColor = ((State)estados[index]).color;
                dialog d = new dialog("Enter the information of the selected state", oldlabel, oldisFinal, oldColor);
                d.ShowDialog(this);
                if ((d.isCorrect) && ((oldlabel != d.text) || (oldisFinal != d.isFinal)) || (oldColor != d.color))
                {
                    saveToolStripMenuItem.Enabled = true;
                    State newState = (State)estados[index];
                    newState.label = d.text;
                    newState.isFinal = d.isFinal;
                    newState.color = d.color;
                    estados.Remove(index);
                    estados.Add(newState.label, newState);
                    //actualizar todas las lineas que tienen como estado source al estado cambiado
                    String[] KeyToRemove = new String[lineas.Count];
                    String[] KeyToUpdate = new String[lineas.Count];
                    String[] automataKeyToUpdate = new String[automata.Count];
                    int counter = 0, counterAutomata = 0;
                    foreach (DictionaryEntry de in lineas)
                    {
                        String[] toCheck = breakKey((String)de.Key);
                        if (toCheck[0] == oldlabel)
                        {
                            KeyToRemove[counter] = (String)de.Key;
                            KeyToUpdate[counter++] = newState.label + ":" + toCheck[1];
                        }
                        if (((Line)de.Value).dest.label == (newState.label))
                        {
                            automataKeyToUpdate[counterAutomata++] = (String)de.Key;
                        }
                    }
                    for (int i = 0; i < counter; i++)
                    {
                        Line lineToUpdate = (Line)lineas[KeyToRemove[i]];
                        String automataToUpdate = (String)automata[KeyToRemove[i]];
                        lineas.Remove(KeyToRemove[i]);
                        automata.Remove(KeyToRemove[i]);
                        lineas.Add(KeyToUpdate[i], lineToUpdate);
                        automata.Add(KeyToUpdate[i], automataToUpdate);
                    }
                    for (int i = 0; i < counterAutomata; i++)
                    {
                        automata.Remove(automataKeyToUpdate[i]);
                        automata.Add(automataKeyToUpdate[i], newState.label);
                    }
                }
            }
            afdDraw.Refresh();
        }

        private void States_Click(object sender, EventArgs e)
        {
            if (statesclicked)
            {
                statesclicked = buttonclicked = false;
                Lineas.Enabled = delete.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = true;
                afdDraw.Cursor = inicial;
            }
            else
            {
                statesclicked = buttonclicked = true;
                Lineas.Enabled = delete.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = false;
                try
                {
                    afdDraw.Cursor = new Cursor("circulo.cur");
                }
                catch (Exception)
                {
                    afdDraw.Cursor = inicial;
                }
            }
        }

        private void Lineas_Click(object sender, EventArgs e)
        {
            if (linesclicked)
            {
                linesclicked = buttonclicked = false;
                States.Enabled = delete.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = true;
                firstStateClicked = intermediatePointclicked = false;
                intermediatePoint.X = intermediatePoint.Y = 0;
                firstState = null;
            }
            else
            {
                linesclicked = buttonclicked = true;
                States.Enabled = delete.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled =  false;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (deleteclicked)
            {
                deleteclicked = buttonclicked = false;
                States.Enabled = Lineas.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = true;
                afdDraw.Cursor = inicial;
            }
            else
            {
                deleteclicked = buttonclicked = true;
                States.Enabled = Lineas.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = false;
                try
                {
                    afdDraw.Cursor = new Cursor("delete.cur");
                }
                catch (Exception)
                {
                    afdDraw.Cursor = inicial;
                }
            }
        }

        public Trace t;
        private void Animate_Click(object sender, EventArgs e)
        {
            if (animateclicked)
            {
                States.Enabled = Lineas.Enabled = delete.Enabled = clear.Enabled = minimiza.Enabled = true;
                animateclicked = panel1.Visible = false;
                timer.Stop();
                foreach (DictionaryEntry de in lineas)
                {
                    Line l = (Line)de.Value;
                    if (l.isActualLine)
                        l.isActualLine = false;
                }
                foreach (DictionaryEntry de in estados)
                {
                    State s = (State)de.Value;
                    if (s.isActualState)
                        s.isActualState = false;
                }
                textBox1.ReadOnly = false;
                textInput = "";
                afdDraw.Refresh();
            }
            else
            {
                if ( (textBox1.Text == "") || (estados.Count == 0) )
                {
                    MessageBox.Show(this, "The input text must contain at least one character", "Input error");
                }
                else
                {
                    t = new Trace(textBox1.Text);
                    t.Show();
                    lastActualLine = "";
                    animateclicked = panel1.Visible =  true;
                    charInString = 0;
                    States.Enabled = Lineas.Enabled = delete.Enabled = clear.Enabled = minimiza.Enabled = false;
                    textInput = textBox1.Text;
                    foreach (DictionaryEntry de in estados)
                    {
                        if (((State)de.Value).isInitial)
                        {
                            actualState = InitialState = ((State)de.Value).label;
                            break;
                        }
                    }
                    State actual = (State)estados[actualState];
                    actual.isActualState = true;
                    t.refresh(actual.label + " ");
                    afdDraw.Refresh();
                    textBox1.ReadOnly = true;
                    timer.Start();
                }
            }
        }

        public ArrayList etapasMinimizacionTD;
        public ArrayList etapasMinimizacionExplicacionTD;
        public int etapasCounterTD;
        public ArrayList etapasMinimizacionBU;
        public ArrayList etapasMinimizacionExplicacionBU;

        private void minimiza_Click(object sender, EventArgs e)
        {
            EscogerAlgoritmo ea = new EscogerAlgoritmo();
            ea.ShowDialog();
            etapasCounterTD = 0;
            etapasMinimizacionTD = new ArrayList();
            etapasMinimizacionExplicacionTD = new ArrayList();
            if (ea.isTopDown)
            {
                topDown();
            }
            else
            {
                etapasMinimizacionBU = new ArrayList();
                etapasMinimizacionExplicacionBU = new ArrayList();
                bottomUp();
            }
        }

        public void topDown()
        {
            oldestados = (Hashtable)estados.Clone();
            oldlineas = (Hashtable)lineas.Clone();
            oldautomata = (Hashtable)automata.Clone();
            Hashtable etapa0 = new Hashtable();
            etapa0.Add("estados", oldestados);
            etapa0.Add("lineas", oldlineas);
            etapa0.Add("automata", oldautomata);
            etapasMinimizacionTD.Add(etapa0);
            etapasMinimizacionExplicacionTD.Add("Initial phase");
            States.Enabled = Lineas.Enabled = delete.Enabled = clear.Enabled = Animate.Enabled = false;
            topleft.Visible = left.Visible = cerrar.Visible = right.Visible = topright.Visible = explicacion.Visible = true;
            reset.Enabled = true;
            minimizaclicked = buttonclicked = minimizaTDclicked = true;
            saveToolStripMenuItem.Enabled = true;

            /********************************************************************************************/
            Boolean isChanged = true;
            while (isChanged)
            {
                isChanged = false;
                Boolean inservible;
                ArrayList estadosInservibles = new ArrayList();

                foreach (DictionaryEntry de in estados)
                {
                    inservible = true;
                    foreach (DictionaryEntry de2 in automata)
                    {
                        if ( ((String)de.Key == (String)de2.Value) && ( (breakKey((String)de2.Key))[0] != (String)de.Key) )
                        {
                            inservible = false;
                            break;
                        }
                    }
                    if ((inservible) && !((State)de.Value).isInitial)
                    {
                        estadosInservibles.Add((String)de.Key);
                        isChanged = true;
                    }
                }
                ArrayList toRemove = new ArrayList();
                for (int i = 0; i < estadosInservibles.Count; i++)
                {
                    String key = (String)estadosInservibles[i];
                    foreach (DictionaryEntry de in lineas)
                    {
                        String[] toCheck = breakKey((String)de.Key);
                        if (toCheck[0] == key)
                            toRemove.Add((String)de.Key);
                        if (((Line)de.Value).dest.label == key)
                            toRemove.Add((String)de.Key);
                    }
                    for (int j = 0; j < toRemove.Count; j++)
                    {
                        lineas.Remove(toRemove[j]);
                        automata.Remove(toRemove[j]);
                    }
                    estados.Remove(key);
                    Hashtable etapaInservible = new Hashtable();
                    etapaInservible.Add("estados", (Hashtable)estados.Clone());
                    etapaInservible.Add("lineas", (Hashtable)lineas.Clone());
                    etapaInservible.Add("automata", (Hashtable)automata.Clone());
                    etapasMinimizacionTD.Add(etapaInservible);
                    etapasMinimizacionExplicacionTD.Add("Eliminacion estados Inservibles: Se elimino estado " + key);
                }
            }

            ArrayList alfabeto = new ArrayList();
            foreach (DictionaryEntry de in automata)
            {
                String[] keys = breakKey((String)de.Key);
                if (!alfabeto.Contains(keys[1]))
                    alfabeto.Add(keys[1]);
            }

            foreach (DictionaryEntry state in estados)
                foreach (String alfa in alfabeto)
                    if (!automata.Contains((String)state.Key + ":" + alfa))
                        automata.Add((String)state.Key + ":" + alfa, "");


            String[] keysOrdenados = ordenar();
            Hashtable finales = new Hashtable();
            Hashtable nofinales = new Hashtable();
            for (int i = 0; i < keysOrdenados.Length; i++)
            {
                State s = (State)estados[keysOrdenados[i]];
                if (s.isFinal)
                    finales.Add(keysOrdenados[i], s);
                else
                    nofinales.Add(keysOrdenados[i], s);
            }

            State estadosFinales = new State(finales);
            State estadosNoFinales = new State(nofinales);
            ArrayList keysEstados = new ArrayList();

            if (finales.Count == 0) 
            {
                MessageBox.Show("No ha asignado estado(s) Finales al automatum!");
                reset.PerformClick();
                return;
            }
            if (nofinales.Count == 0)
            {
                MessageBox.Show("No ha asignado estado(s) No Finales al automatum!");
                reset.PerformClick();
                return;
            }


            keysEstados.Add(estadosNoFinales.label);
            keysEstados.Add(estadosFinales.label);
            estados.Clear();
            estados.Add(estadosFinales.label, estadosFinales);
            estados.Add(estadosNoFinales.label, estadosNoFinales);



            int iteracion = 1;
            Hashtable etapa1 = new Hashtable();
            etapa1.Add("estados", cloneState(estados));
            etapa1.Add("lineas", new Hashtable());
            etapa1.Add("automata", new Hashtable());
            etapasMinimizacionTD.Add(etapa1);
            etapasMinimizacionExplicacionTD.Add("Etapa 1: Separacion Estados finales y no finales");

            isChanged = true;
            while (isChanged) // ciclo general
            {
                isChanged = false;
                ArrayList listToRemove = new ArrayList();
                for (int i = 0; i < keysEstados.Count; i++)
                {
                    Hashtable toRemove = new Hashtable();
                    String statesRemoved = "";
                    State thisState = (State)estados[keysEstados[i]];
                    Hashtable destinos = new Hashtable();
                    foreach (String alfa in alfabeto)
                    {
                        String dest = (String)automata[thisState.get(0).label + ":" + alfa];
                        String toAddInDestinos = getDestinoStateLabel(estados, dest);
                        destinos.Add(alfa, toAddInDestinos);
                    }
                    for (int j = 1; j < thisState.states.Length; j++)
                    {
                        State sj = (State)thisState.get(j);
                        foreach (String alfa in alfabeto)
                        {
                            String dest = (String)automata[sj.label + ":" + alfa];
                            String toAddInDestinos = getDestinoStateLabel(estados, dest);
                            if (toAddInDestinos != ((String)destinos[alfa]))
                            {
                                isChanged = true;
                                toRemove.Add(sj.label, sj);
                                statesRemoved += " " + sj.label;
                                break;
                            }
                        }
                    }
                    if (toRemove.Count > 0) {
                        estados.Remove(thisState.label);
                        thisState.remove(toRemove);
                        keysEstados[i] = thisState.label;
                        estados.Add(thisState.label, thisState);
                        State newState = new State(toRemove);
                        estados.Add(newState.label, newState);
                        listToRemove.Add(toRemove);
                        Hashtable etapai = new Hashtable();
                        etapai.Add("estados", cloneState(estados));
                        etapai.Add("lineas", new Hashtable());
                        etapai.Add("automata", new Hashtable());
                        etapasMinimizacionTD.Add(etapai);
                        etapasMinimizacionExplicacionTD.Add("Etapa " + (++iteracion) + ": Estados separados: " + statesRemoved);
                    }
                }
                for (int i = 0; i < listToRemove.Count; i++) {
                    State newState = new State((Hashtable)listToRemove[i]);
                    keysEstados.Add(newState.label);
                }
            }

            Hashtable newAutomata = new Hashtable();
            Hashtable newLines = new Hashtable();
            Hashtable linesAdded = new Hashtable();
            for (int i = 0; i < keysEstados.Count; i++)
            {
                State si = (State)estados[keysEstados[i]];
                for (int j = 0; j < keysEstados.Count; j++)
                {
                    foreach (String alfa in alfabeto)
                    {
                        State sj = (State)estados[keysEstados[j]];
                    //    if (si.esConjuntoDeEstados)
                        //{
                            for (int k = 0; k < si.states.Length; k++)
                                if (sj.contains((String)automata[si.get(k).label + ":" + alfa]))
                                {
                                    newAutomata.Add(si.label + ":" + alfa, sj.label);
                                    if ((oldlineas.ContainsKey(si.label + ":" + alfa)) && (((Line)oldlineas[si.label + ":" + alfa]).dest.label == sj.label))
                                    {
                                        newLines.Add(si.label + ":" + alfa, (Line)oldlineas[si.label + ":" + alfa]);
                                    }
                                    else
                                    {
                                        int imx;
                                        int imy;
                                        int dy = sj.y - si.y;
                                        int dx = sj.x - si.x;
                                        imy = si.y + (dy / 2);
                                        imx = si.x + (dx / 2);
                                        if (!linesAdded.ContainsKey(si.label))
                                        {
                                            linesAdded.Add(si.label, 1);
                                        }
                                        else
                                        {
                                            int toAdd = (int)linesAdded[si.label];
                                            imy -= toAdd * 35;
                                            linesAdded.Remove(si.label);
                                            linesAdded.Add(si.label, (++toAdd));
                                        }
                                        if (!linesAdded.ContainsKey(sj.label))
                                            linesAdded.Add(sj.label, 1);
                                        else
                                        {
                                            int toAdd = (int)linesAdded[sj.label] + 1;
                                            linesAdded.Remove(sj.label);
                                            linesAdded.Add(sj.label, toAdd);
                                        }

                                        if (si.label == sj.label)
                                        {
                                            imx = si.x + 50;
                                            imy = si.y - 20;
                                            if (!linesAdded.ContainsKey(si.label + si.label))
                                                linesAdded.Add(si.label + si.label, 1);
                                            else
                                            {
                                                int toAdd = (int)linesAdded[si.label + si.label];
                                                imy -= toAdd;
                                                linesAdded.Remove(si.label + si.label);
                                                linesAdded.Add(si.label + si.label, (++toAdd));
                                            }
                                        }

                                        Line l = new Line(si, sj, imx, imy);
                                        l.label = alfa;
                                        newLines.Add(si.label + ":" + alfa, l);
                                    }
                                    break;
                                }
                        }
                    }
                }
            automata = newAutomata;
            lineas = newLines;
            Hashtable etapafinal = new Hashtable();
            etapafinal.Add("estados", cloneState(estados));
            etapafinal.Add("lineas", (Hashtable)lineas.Clone());
            etapafinal.Add("automata", (Hashtable)automata.Clone());
            etapasMinimizacionTD.Add(etapafinal);
            etapasMinimizacionExplicacionTD.Add("Etapa Final: Asi esta minimizado el Automatum");
            afdDraw.Refresh();
        }

        public Hashtable cloneState(Hashtable origen)
        {
            Hashtable destino = new Hashtable();
            foreach (DictionaryEntry de in origen)
            {
                State stateOrigen = (State)de.Value;
                Color newColor = stateOrigen.color;
                Boolean newesConjuntoDeEstados = stateOrigen.esConjuntoDeEstados;
                Boolean newisActualState = stateOrigen.isActualState;
                Boolean newisFinal = stateOrigen.isFinal;
                Boolean newisInitial = stateOrigen.isInitial;
                String newlabel = stateOrigen.label;
                State[] newstates = stateOrigen.states;
                int newx = stateOrigen.x;
                int newy = stateOrigen.y;
                State newState = new State(newlabel, newx, newy);
                newState.color = newColor;
                newState.esConjuntoDeEstados = newesConjuntoDeEstados;
                newState.isActualState = newisActualState;
                newState.isFinal = newisFinal;
                newState.isInitial = newisInitial;
                destino.Add(newState.label, newState);
            }
            return destino;
        }

        public String getDestinoStateLabel(Hashtable toCheck, String stringToCheck)
        {
            foreach(DictionaryEntry de in toCheck)
            {
                State si = (State)de.Value;
                if (si.contains(stringToCheck))
                    return si.label;
            }
            return ""; // esto NO DEBERIA PASAR!
        }

        public Hashtable crearTabla(ArrayList keys)
        {
            Hashtable tabla = new Hashtable();
            for (int i = 0; i < (keys.Count - 1); i++)
                for (int j = (i+1); j < keys.Count; j++)
                    tabla.Add((String)keys[i] + ":" + (String)keys[j], "");
            return tabla;
        }

        public void bottomUp()
        {
            oldestados = (Hashtable)estados.Clone();
            oldlineas = (Hashtable)lineas.Clone();
            oldautomata = (Hashtable)automata.Clone();
            Hashtable etapa0 = new Hashtable();
            etapa0.Add("estados", oldestados);
            etapa0.Add("lineas", oldlineas);
            etapa0.Add("automata", oldautomata);
            etapasMinimizacionTD.Add(etapa0);
            etapasMinimizacionExplicacionTD.Add("Etapa Inicial");

            States.Enabled = Lineas.Enabled = delete.Enabled = clear.Enabled = Animate.Enabled = false;
            topleft.Visible = left.Visible = cerrar.Visible = right.Visible = topright.Visible = explicacion.Visible = true;
            reset.Enabled = true;
            minimizaclicked = buttonclicked = minimizaBUclicked = true;
            saveToolStripMenuItem.Enabled = true;

            /********************************************************************************************/
            Boolean isChanged = true; // quitar estados inservibles (unreachable)
            while (isChanged)
            {
                isChanged = false;
                Boolean inservible;
                ArrayList estadosInservibles = new ArrayList();

                foreach (DictionaryEntry de in estados)
                {
                    inservible = true;
                    foreach (DictionaryEntry de2 in automata)
                    {
                        if (((String)de.Key == (String)de2.Value) && ((breakKey((String)de2.Key))[0] != (String)de.Key))
                        {
                            inservible = false;
                            break;
                        }
                    }
                    if ((inservible) && !((State)de.Value).isInitial)
                    {
                        estadosInservibles.Add((String)de.Key);
                        isChanged = true;
                    }
                }
                ArrayList toRemove = new ArrayList();
                for (int i = 0; i < estadosInservibles.Count; i++)
                {
                    String key = (String)estadosInservibles[i];
                    foreach (DictionaryEntry de in lineas)
                    {
                        String[] toCheck = breakKey((String)de.Key);
                        if (toCheck[0] == key)
                            toRemove.Add((String)de.Key);
                        if (((Line)de.Value).dest.label == key)
                            toRemove.Add((String)de.Key);
                    }
                    for (int j = 0; j < toRemove.Count; j++)
                    {
                        lineas.Remove(toRemove[j]);
                        automata.Remove(toRemove[j]);
                    }
                    estados.Remove(key);
                    Hashtable etapaInservible = new Hashtable();
                    etapaInservible.Add("estados", (Hashtable)estados.Clone());
                    etapaInservible.Add("lineas", (Hashtable)lineas.Clone());
                    etapaInservible.Add("automata", (Hashtable)automata.Clone());
                    etapasMinimizacionTD.Add(etapaInservible);
                    etapasMinimizacionExplicacionTD.Add("Eliminacion estados Inservibles: Se elimino estado " + key);
                }
            }

            ArrayList alfabeto = new ArrayList(); // sacamos alfabeto
            foreach (DictionaryEntry de in automata)
            {
                String[] keys = breakKey((String)de.Key);
                if (!alfabeto.Contains(keys[1]))
                    alfabeto.Add(keys[1]);
            }
            State estadoBasura = new State("sBasura", -40, -40);
            estadoBasura.isFinal = false;
            estados.Add(estadoBasura.label, estadoBasura);

            foreach (DictionaryEntry state in estados) // llenamos bien la matriz automata
                foreach (String alfa in alfabeto)
                    if (!automata.Contains((String)state.Key + ":" + alfa))
                        automata.Add((String)state.Key + ":" + alfa, estadoBasura.label);


            /********************************************************************************************/

            /**********************************************************************************************
             * Comienza algoritmo de minimizacion bottom-up
             **********************************************************************************************/

            String[] keysOrdenados = ordenar();
            ArrayList keysEstados = new ArrayList();
            for (int i = 0; i < keysOrdenados.Length; i++)
                keysEstados.Add(keysOrdenados[i]);

            int iteraciones = 0;
            Hashtable pairTable = crearTabla(keysEstados);
            Hashtable pairTableInicial = new Hashtable();
            int contadorMarked = 1;
            foreach (DictionaryEntry de in pairTable)
            {
                String[] keys = breakKey((String)de.Key);
                if (((State)estados[keys[0]]).isFinal != ((State)estados[keys[1]]).isFinal)
                {
                    pairTableInicial.Add((String)de.Key, "X:" + iteraciones);
                    contadorMarked++;
                }
                else
                    pairTableInicial.Add((String)de.Key, "");
            }
            iteraciones++;

            pairTable = (Hashtable)pairTableInicial.Clone();
            etapasMinimizacionBU.Add((Hashtable)pairTable.Clone());
            etapasMinimizacionExplicacionBU.Add("Pair Table inicial");
            while (contadorMarked > 0)
            {
                contadorMarked = 0;
                Hashtable newPairTable = new Hashtable();
                foreach (DictionaryEntry de in pairTable)
                {
                    if ((String)de.Value == "") // estos hay que revisarlos!
                    {
                        String estadoP = (breakKey((String)de.Key))[0];
                        String estadoQ = (breakKey((String)de.Key))[1];
                        foreach (String alfa in alfabeto)
                        {
                            String marked = (String)pairTable[(String)automata[estadoP + ":" + alfa] + ":" + (String)automata[estadoQ + ":" + alfa]];
                            if (!String.IsNullOrEmpty(marked))
                            {
                                int markedIteracion = int.Parse((breakKey(marked))[1]);
                                if (markedIteracion == (iteraciones - 1))
                                {
                                    newPairTable.Add((String)de.Key, "X:" + iteraciones);
                                    contadorMarked++;
                                    break;
                                }
                            }
                            marked = (String)pairTable[(String)automata[estadoQ + ":" + alfa] + ":" + (String)automata[estadoP + ":" + alfa]];
                            if (!String.IsNullOrEmpty(marked))
                            {
                                int markedIteracion = int.Parse((breakKey(marked))[1]);
                                if (markedIteracion == (iteraciones - 1))
                                {
                                    newPairTable.Add((String)de.Key, "X:" + iteraciones);
                                    contadorMarked++;
                                    break;
                                }
                            }

                        }
                        if (!(newPairTable.ContainsKey((String)de.Key)))
                            newPairTable.Add((String)de.Key, "");
                    }
                    else
                    {
                        newPairTable.Add((String)de.Key, (String)de.Value);
                    }
                }
                pairTable = (Hashtable)newPairTable.Clone();
                etapasMinimizacionBU.Add((Hashtable)newPairTable.Clone());
                etapasMinimizacionExplicacionBU.Add("Pair Table: iteracion " + iteraciones);

                if (contadorMarked > 0)
                    iteraciones++;
            }

            ArrayList pairTableKeys = new ArrayList();
            foreach (DictionaryEntry de in pairTable)
            {
                if ( ((breakKey((String)de.Key))[0] != "sBasura") && ((breakKey((String)de.Key))[1] != "sBasura") )
                    pairTableKeys.Add((String)de.Key);
            }
            estados.Remove(estadoBasura.label);

            ArrayList newStates = new ArrayList();
                for (int i = 0; i < pairTableKeys.Count; i++)
                {
                    if (((String)pairTable[pairTableKeys[i]]) == "")
                    {
                        String estadoPi = breakKey((String)pairTableKeys[i])[0];
                        String estadoQi = breakKey((String)pairTableKeys[i])[1];
                        ArrayList newState = new ArrayList();
                        newState.Add(estadoPi);
                        newState.Add(estadoQi);
                        for (int j = 0; j < pairTableKeys.Count; j++)
                        {
                            if (((String)pairTable[pairTableKeys[j]]) == "")
                            {
                                String estadoPj = breakKey((String)pairTableKeys[j])[0];
                                String estadoQj = breakKey((String)pairTableKeys[j])[1];
                                if ((estadoPi == estadoPj) || (estadoQi == estadoPj) || (estadoPi == estadoQj) || (estadoQi == estadoQj))
                                {
                                    if (!newState.Contains(estadoPj))
                                        newState.Add(estadoPj);
                                    if (!newState.Contains(estadoQj))
                                        newState.Add(estadoQj);
                                }
                            }
                        }

                        Boolean isNew = true;
                        foreach (String de in newState)
                        {
                            foreach (ArrayList de2 in newStates)
                            {
                                if (de2.Contains(de))  // esta contenido en un macroestado
                                {
                                    isNew = false;
                                    break;
                                }
                            }
                        }
                        if (isNew)
                            newStates.Add(newState);
                    }
                }

                Hashtable nuevosEstados = new Hashtable();
            for (int i = 0; i < newStates.Count; i++)
            {
                Hashtable nuevoEstado = new Hashtable();
                foreach (String state in (ArrayList)newStates[i])
                    nuevoEstado.Add(state, (State)estados[state]);
                State newState = new State(nuevoEstado);
                if (!nuevosEstados.ContainsKey(newState.label))
                    nuevosEstados.Add(newState.label, newState);
            }

            foreach (DictionaryEntry de in estados)
            {
                Boolean isNew = true;
                foreach (DictionaryEntry de2 in nuevosEstados)
                {
                    if (((State)de2.Value).contains((String)de.Key))  // esta contenido en un macroestado
                    {
                        isNew = false;
                        break;
                    }
                }
                if (isNew)
                    nuevosEstados.Add((String)de.Key, (State)de.Value);
            }
            estados = (Hashtable)nuevosEstados.Clone();


            Hashtable newAutomata = new Hashtable();
            Hashtable newLines = new Hashtable();
            Hashtable linesAdded = new Hashtable();
            foreach (DictionaryEntry de in estados)
            {
                State si = (State)de.Value;
                foreach (DictionaryEntry de2 in estados)
                {
                    foreach (String alfa in alfabeto)
                    {
                        State sj = (State)de2.Value;
                        if (si.esConjuntoDeEstados)
                        {
                            for (int k = 0; k < si.states.Length; k++)
                                if (sj.contains((String)automata[si.get(k).label + ":" + alfa]))
                                {
                                    try
                                    {
                                        newAutomata.Add(si.label + ":" + alfa, sj.label);
                                        if ((oldlineas.ContainsKey(si.label + ":" + alfa)) && (((Line)oldlineas[si.label + ":" + alfa]).dest.label == sj.label))
                                        {
                                            newLines.Add(si.label + ":" + alfa, (Line)oldlineas[si.label + ":" + alfa]);
                                        }
                                        else
                                        {
                                            int imx;
                                            int imy;
                                            int dy = sj.y - si.y;
                                            int dx = sj.x - si.x;
                                            imy = si.y + (dy / 2);
                                            imx = si.x + (dx / 2);
                                            if (!linesAdded.ContainsKey(si.label))
                                            {
                                                linesAdded.Add(si.label, 1);
                                            }
                                            else
                                            {
                                                int toAdd = (int)linesAdded[si.label];
                                                imy -= toAdd * 35;
                                                linesAdded.Remove(si.label);
                                                linesAdded.Add(si.label, (++toAdd));
                                            }
                                            if (!linesAdded.ContainsKey(sj.label))
                                                linesAdded.Add(sj.label, 1);
                                            else
                                            {
                                                int toAdd = (int)linesAdded[sj.label] + 1;
                                                linesAdded.Remove(sj.label);
                                                linesAdded.Add(sj.label, toAdd);
                                            }

                                            if (si.label == sj.label)
                                            {
                                                imx = si.x + 50;
                                                imy = si.y - 20;
                                                if (!linesAdded.ContainsKey(si.label + si.label))
                                                    linesAdded.Add(si.label + si.label, 1);
                                                else
                                                {
                                                    int toAdd = (int)linesAdded[si.label + si.label];
                                                    imy -= toAdd;
                                                    linesAdded.Remove(si.label + si.label);
                                                    linesAdded.Add(si.label + si.label, (++toAdd));
                                                }
                                            }

                                            Line l = new Line(si, sj, imx, imy);
                                            l.label = alfa;
                                            newLines.Add(si.label + ":" + alfa, l);
                                        }
                                        break;
                                    }
                                    catch (Exception) { }
                                }
                        }
                        else
                        {
                            if (sj.contains((String)automata[si.label + ":" + alfa]))
                            {
                                try
                                {
                                    newAutomata.Add(si.label + ":" + alfa, sj.label);
                                    if ((oldlineas.ContainsKey(si.label + ":" + alfa)) && (((Line)oldlineas[si.label + ":" + alfa]).dest.label == sj.label))
                                    {
                                        newLines.Add(si.label + ":" + alfa, (Line)oldlineas[si.label + ":" + alfa]);
                                    }
                                    else
                                    {
                                        int imx;
                                        int imy;
                                        int dy = sj.y - si.y;
                                        int dx = sj.x - si.x;
                                        imy = si.y + (dy / 2);
                                        imx = si.x + (dx / 2);
                                        if (!linesAdded.ContainsKey(si.label))
                                        {
                                            linesAdded.Add(si.label, 1);
                                        }
                                        else
                                        {
                                            int toAdd = (int)linesAdded[si.label];
                                            imy -= toAdd * 20;
                                            linesAdded.Remove(si.label);
                                            linesAdded.Add(si.label, (++toAdd));
                                        }
                                        if (si.label == sj.label)
                                        {
                                            imx = si.x + 50;
                                            imy = si.y - 20;
                                            if (!linesAdded.ContainsKey(si.label + si.label))
                                                linesAdded.Add(si.label + si.label, 1);
                                            else
                                            {
                                                int toAdd = (int)linesAdded[si.label + si.label];
                                                imy -= toAdd;
                                                linesAdded.Remove(si.label + si.label);
                                                linesAdded.Add(si.label + si.label, (++toAdd));
                                            }

                                        }
                                        Line l = new Line(si, sj, imx, imy);
                                        l.label = alfa;
                                        newLines.Add(si.label + ":" + alfa, l);
                                    }
                                }
                                catch (Exception) { }
                            } 
                        }
                    }
                }
            }
            automata = newAutomata;
            lineas = newLines;
            Hashtable etapafinal = new Hashtable();
            etapafinal.Add("estados", cloneState(estados));
            etapafinal.Add("lineas", (Hashtable)lineas.Clone());
            etapafinal.Add("automata", (Hashtable)automata.Clone());
            etapasMinimizacionTD.Add(etapafinal);
            etapasMinimizacionExplicacionTD.Add("Etapa Final: Asi esta minimizado el Automatum");
            BottomUpAlgorithm bua = new BottomUpAlgorithm(etapasMinimizacionBU, etapasMinimizacionExplicacionBU);
            bua.Show();
            afdDraw.Refresh();
        }

        private void rightClick(int x, int y)
        {
            if (deleteclicked)
            {
                String index = clickedOnAState(x, y);
                if (index != null)
                {
                    if (index != null)
                    {
                        String message;
                        String caption;
                        if (InitialState == index)
                        {
                            MessageBox.Show("No se puede borrar el estado debido a que es el estado inicial", "Borrar estado inicial", MessageBoxButtons.OK);
                            goto finborrar;
                        }
                        else
                        {
                            message = "Esta seguro que desea borrar el Estado \"" + index + "\" ?";
                            caption = "Borrar Estado \"" + index + "\" ?";
                        }
                        DialogResult result = MessageBox.Show(this, message, caption, MessageBoxButtons.OKCancel);
                        if (result == DialogResult.Cancel)
                            goto finborrar;
                        estados.Remove(index);
                        if (InitialState == index)
                            InitialState = "";
                        // borrar todas las lineas que esten unidas a este estado
                        String[] toRemove = new String[lineas.Count];
                        int counter = 0;
                        foreach (DictionaryEntry de in lineas)
                        {
                            String[] toCheck = breakKey((String)de.Key);
                            if (toCheck[0] == index)
                                toRemove[counter++] = (String)de.Key;
                            if (((Line)de.Value).dest.label == index)
                                toRemove[counter++] = (String)de.Key;
                        }
                        for (int i = 0; i < counter; i++)
                        {
                            lineas.Remove(toRemove[i]);
                            automata.Remove(toRemove[i]);
                        }
                    }
 finborrar:         deleteclicked = buttonclicked = false;
                    afdDraw.Cursor = inicial;
                    States.Enabled = Lineas.Enabled = Animate.Enabled = minimiza.Enabled = clear.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    afdDraw.Refresh();
                }
            }
        }

        public String clickedOnAState(int x, int y)
        {
            foreach (DictionaryEntry de in estados)
            {
                State s = (State)de.Value;
                if ((x > s.x) && (x < (s.x + 30)) && (y > s.y) && (y < (s.y + 30)))
                    return s.label;
            }
            return null;
        }

        public String[] breakKey(String key)
        {
            String stateKey = "";
            String caracterKey = "";
            String[] toReturn = new String[2];
            int i = 0;
            for (i = 0; i < key.Length; i++) {
                if (key[i] == ':')
                    break;
            }
            stateKey = key.Substring(0, i);
            caracterKey = key.Substring(i+1);
            toReturn[0] = stateKey;
            toReturn[1] = caracterKey;
            return toReturn;
        }

        public String lastActualLine = "";
        private void timer_Tick(object sender, EventArgs e)
        {
            String nextChar = "";
            if (actualState == "")
                actualState = InitialState;

            State actual = (State)estados[actualState];
            actual.isActualState = true;
            afdDraw.Refresh();
            try
            {
                nextChar = "" + textInput[textInputCounter++];
                t.refresh(" --> ");
            }
            catch (Exception)
            {
                if (((State)estados[actualState]).isFinal)
                {
                    timer.Stop();
                    textInputCounter = 0;
                    State finalStateChecked = (State)estados[actualState];
                    finalStateChecked.isActualState = false;
                    MessageBox.Show("CUERDA ACEPTADA!", "Aceptada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afdDraw.Refresh();
                    Animate.PerformClick();
                }
                else
                {
                    t.refresh(" -> XX <-- ");
                    cuerdaNoAceptada();
                }
                return;
            }
            charInString = (textInputCounter - 1);
            panel1.Refresh();

            if (lastActualLine != "")
            {
                Line l = (Line)lineas[lastActualLine];
                l.isActualLine = false;
            }


            if (automata.Contains(actualState + ":" + nextChar))
            {
                State s = (State)estados[actualState];
                s.isActualState = false;
                Line line = (Line)lineas[actualState + ":" + nextChar];
                line.isActualLine = true;
                lastActualLine = actualState + ":" + nextChar;
                actualState = (String)automata[actualState + ":" + nextChar];
                State state = (State)estados[actualState];
                state.isActualState = true;
                t.refresh(state.label + " ");
            }
            else
            {
                t.refresh(" XX <--");
                cuerdaNoAceptada();
            }
            afdDraw.Refresh();

        }

        public void cuerdaNoAceptada()
        {
            textInputCounter = 0;
            State finalStateChecked = (State)estados[actualState];
            finalStateChecked.isActualState = false;
            timer.Stop();
            afdDraw.Refresh();
            MessageBox.Show("CUERDA INGRESADA NO ACEPTADA POR EL AUTOMATUM!", "cuerda no aceptada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Animate.PerformClick();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            tabPage2.Refresh();
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            g2 = e.Graphics;
            g2.TranslateTransform(panel2.AutoScrollPosition.X, panel2.AutoScrollPosition.Y);
            Pen pencil = new Pen(Color.Black, 2);
            ArrayList alfabeto = new ArrayList();
            Font font = new Font("Arial", 13);
            Font font2 = new Font("Arial", 15, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush brush2 = new SolidBrush(Color.Blue);
/*            Point A = new Point();
            Point B = new Point();*/
            int j, x, y, w, z = 0;

            Size scrollOffset = new Size(panel2.AutoScrollPosition);

            foreach (DictionaryEntry de in automata)
            {
                String[] keys = breakKey((String)de.Key);
                if (!alfabeto.Contains(keys[1]))
                    alfabeto.Add(keys[1]);
            }
            int a = alfabeto.Count;
            int s = estados.Count;
            int d = (a / 2) + 1;

            int temp1 = 876;
            int temp2 = 586;

            if ((a > 6) && (s > 12))
            {
                panel2.Size = new Size((temp1 + ((a - 6) * 75)), (temp2 + ((s - 12) * 40)));
            }
            else
            {
                if (a > 6)
                    panel2.Size = new Size((temp1 + ((a - 6) * 75)), temp2);
                if (s > 12)
                    panel2.Size = new Size(temp1, (temp2 + ((s - 12) * 40)));
            }

            x = (panel2.Size.Width / 2) - 100 - (d * 75);

            y = 50;
            w = ((a + 1) * 100);
            z = ((s + 1) * 40);
            g2.DrawRectangle(pencil, x + scrollOffset.Width, y + scrollOffset.Height, w, z);
            w = w + x;
            z = z + y;
            j = x + 45;
            for (int i = (a - 1); i >= 0; i--)
            {
                j += 100;
                g2.DrawString((String)alfabeto[i], font2, brush, new Point(j + scrollOffset.Width, (y + 8) + scrollOffset.Height));
                x += 100;
                w = x;
                g2.DrawLine(pencil, new Point(x + scrollOffset.Width, y + scrollOffset.Height), new Point(w + scrollOffset.Width, z + scrollOffset.Height));

            }
            x = (panel2.Size.Width / 2) - 100 - (d * 75);
//            foreach (DictionaryEntry de in estados)
            String[] keysEstados = ordenar();
            for (int i = 0; i < keysEstados.Length; i++)
            {
                //String s2 = (String)de.Key;
                //State s3 = (State)de.Value;
                String s2 = keysEstados[i];
                State s3 = (State)estados[keysEstados[i]];
                y = y + 40;
                if (!(s3.isFinal))
                    g2.DrawString(s2, font2, brush, new Point((x + 25) + scrollOffset.Width, (y + 8) + scrollOffset.Height));
                else
                    g2.DrawString(s2, font2, brush2, new Point((x + 25) + scrollOffset.Width, (y + 8) + scrollOffset.Height));
                w = x + ((a + 1) * 100);
                z = y;
                g2.DrawLine(pencil, new Point(x + scrollOffset.Width, y + scrollOffset.Height), new Point(w + scrollOffset.Width, z + scrollOffset.Height));
            }
            String clave;
            y = 80;
//            foreach (DictionaryEntry de in estados)
            for (int k = 0; k < keysEstados.Length; k++)
            {
                x = (panel2.Size.Width / 2) - (d * 75);
                //String s2 = (String)de.Key;
                String s2 = keysEstados[k];
                for (int i = (a - 1); i >= 0; i--)
                {
                    clave = s2 + ":" + (String)alfabeto[i];
                    if (!String.IsNullOrEmpty((String)automata[clave]))
                        g2.DrawString((String)automata[clave], font, brush, new Point((x + 25) + scrollOffset.Width, (y + 15) + scrollOffset.Height));
                    else
                        g2.DrawString("XX", font, brush, new Point((x + 25) + scrollOffset.Width, (y + 15) + scrollOffset.Height));
                    x += 100;
                }
                y += 40;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            automata.Clear();
            lineas.Clear();
            estados.Clear();
            counterstates = -1;
            textBox1.Clear();
            InitialState = "";
            afdDraw.Refresh();
        }

        private void newStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            States.PerformClick();
        }

        private void newLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lineas.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete.PerformClick();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear.PerformClick();
            afnLimpiar.PerformClick();
        }

        private void simularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Animate.PerformClick();
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimiza.PerformClick();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear.PerformClick();
            afnLimpiar.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
            {
                String message, caption;
                if (estados.Count > 0)
                {
                    if (fileName != null)
                    {
                        message = "Desea grabar el archivo " + fileName + "?";
                        caption = "Grabar archivo " + fileName;
                    }
                    else
                    {
                        message = "Desea guardar el automatum creado?";
                        caption = "Guardar automatum";
                    }
                    DialogResult result = MessageBox.Show(this, message, caption, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        saveToolStripMenuItem.PerformClick();
                    else
                    {
                        saveToolStripMenuItem.Enabled = false;
                        openToolStripMenuItem.PerformClick();
                    }
                }
                else
                {
                    saveToolStripMenuItem.Enabled = false;
                    openToolStripMenuItem.PerformClick();
                }
            }
            else
            {
                openFileDialog1.Title = "Abrir archivo AutomatumSimulator (AS)";
                saveToolStripMenuItem.Enabled = true;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    Hashtable oldestados, oldlineas, oldautomata;
                    oldestados = estados;
                    oldlineas = lineas;
                    oldautomata = automata;
                    try
                    {
                        IFormatter formatter = new BinaryFormatter();
                        FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                        Hashtable automatum = (Hashtable)formatter.Deserialize(fs);
                        // ver Exceptions
                        fs.Close();
                        estados = (Hashtable)automatum["estados"];
                        lineas = (Hashtable)automatum["lineas"];
                        automata = (Hashtable)automatum["automata"];
                        estadosAfn = (Hashtable)automatum["estadosAfn"];
                        lineasAfn = (Hashtable)automatum["lineasAfn"];
                        foreach (DictionaryEntry de in estados)
                        {
                            if (((State)de.Value).isInitial)
                                actualState = InitialState = ((State)de.Value).label;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al abrir archivo, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        estados = oldestados;
                        lineas = oldlineas;
                        automata = oldautomata;
                    }
                    afdDraw.Refresh();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar Archivo AutomatumSimulator (AS)";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileStream toSave = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    IFormatter formatter = new BinaryFormatter();
                    BinaryWriter bw = new BinaryWriter(toSave);
                    Hashtable automatum = new Hashtable();
                    automatum.Add("estados", estados);
                    automatum.Add("lineas", lineas);
                    automatum.Add("automata", automata);
                    automatum.Add("estadosAfn", estadosAfn);
                    automatum.Add("lineasAfn", lineasAfn);

                    formatter.Serialize(toSave, automatum);
                    fileName = saveFileDialog1.FileName;
                    toSave.Close();
                    saveToolStripMenuItem.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("error al grabar el archivo", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar Archivo como... (AS)";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileStream toSave = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    IFormatter formatter = new BinaryFormatter();
                    BinaryWriter bw = new BinaryWriter(toSave);
                    Hashtable automatum = new Hashtable();
                    automatum.Add("estados", estados);
                    automatum.Add("lineas", lineas);
                    automatum.Add("automata", automata);
                    automatum.Add("estadosAfn", estadosAfn);
                    automatum.Add("lineasAfn", lineasAfn);

                    formatter.Serialize(toSave, automatum);
                    fileName = saveFileDialog1.FileName;
                    toSave.Close();
                    saveToolStripMenuItem.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("error al grabar el archivo", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear.PerformClick();
            afnLimpiar.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private int charInString;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int xInicial = (int)((850 / 2) - (textInput.Length * 5));
            Graphics gCuerda = panel1.CreateGraphics();
            SolidBrush sd = new SolidBrush(Color.Black);
            Font f = new Font("Tahoma", 20);
            for (int i = 0; i < textInput.Length; i++)
            {
                if (i == charInString)
                    sd.Color = Color.Blue;
                else
                    sd.Color = Color.Black;
                gCuerda.DrawString("" + textInput[i], f, sd, xInicial + 5 + (i * 13), 5);
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            if (minimizaclicked)
                cerrar.PerformClick();
            reset.Enabled = false;
            estados = oldestados;
            lineas = oldlineas;
            automata = oldautomata;
            afdDraw.Refresh();
        }

        private String[] ordenar()
        {
            String[] keys = new String[estados.Count];
            int counter = 0;
            foreach (DictionaryEntry de in estados)
            {
                keys[counter++] = (String)de.Key;
            }
            Boolean isChanged = true;
            while (isChanged) {
                isChanged = false;
                for (int i = 0; i < (keys.Length-1); i++)
                    if (String.CompareOrdinal(keys[i], keys[i + 1]) > 0)
                    {
                        isChanged = true;
                        String toSwap = keys[i];
                        keys[i] = keys[i + 1];
                        keys[i + 1] = toSwap;
                    }
            }
            return keys;
        }

        private String[] ordenarAfn()
        {
            String[] keys = new String[estadosAfn.Count];
            int counter = 0;
            foreach (DictionaryEntry de in estadosAfn)
            {
                keys[counter++] = (String)de.Key;
            }
            Boolean isChanged = true;
            while (isChanged)
            {
                isChanged = false;
                for (int i = 0; i < (keys.Length - 1); i++)
                    if (String.CompareOrdinal(keys[i], keys[i + 1]) > 0)
                    {
                        isChanged = true;
                        String toSwap = keys[i];
                        keys[i] = keys[i + 1];
                        keys[i + 1] = toSwap;
                    }
            }
            return keys;
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            topleft.Visible = left.Visible = cerrar.Visible = right.Visible = topright.Visible = explicacion.Visible = false;
            States.Enabled = Lineas.Enabled = delete.Enabled = clear.Enabled = Animate.Enabled = true;
            minimizaclicked = minimizaBUclicked = minimizaTDclicked = false;
            etapasCounterTD = 0;
            afdDraw.Refresh();
        }

        private void topleft_Click(object sender, EventArgs e)
        {
            etapasCounterTD = 0;
            afdDraw.Refresh();
        }

        private void left_Click(object sender, EventArgs e)
        {
            etapasCounterTD--;
            afdDraw.Refresh();
        }

        private void right_Click(object sender, EventArgs e)
        {
            etapasCounterTD++;
            afdDraw.Refresh();
        }

        private void topright_Click(object sender, EventArgs e)
        {
            etapasCounterTD = etapasMinimizacionTD.Count - 1;
            afdDraw.Refresh();
        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            panel2.Refresh();
        }

/********************************************CODIGO AFN********************************************/
        public Hashtable estadosAfn = new Hashtable();
        public Hashtable lineasAfn = new Hashtable();
        public Hashtable automataAfn = new Hashtable();
        public int contadorEstadosAfn = 0;
        public Boolean afnEstadosClicked = false;
        public Boolean afnLineasClicked = false;
        public Boolean afnDeleteClicked = false;
        public Boolean afnAnimateClicked = false;
        public Boolean estadoSourceClicked = false;
        public Boolean ptoIntermedioClicked = false;
        public Boolean estadoSourceABorrarClicked = false;
        public int x;
        public int y;
        public String labelSource;
        public String labelSourceABorrar;
        public String labelDest;
        public String afnTextInput = "";
        public String afnlastActualLineKey, afnlastActualLineHtKey, afnactualState, afnInitialState;
        public int afncharInString = 0;
        public int afnTextInputCounter = 0;
        public int interX;
        public int interY;

        public Hashtable automataNuevoAfd = new Hashtable();
        public Hashtable lineasNuevasAfd = new Hashtable();
        public Hashtable EstadosD = new Hashtable();
        public Hashtable EstadosDAfd = new Hashtable();
        public Hashtable oldEstadosAfn = new Hashtable();
        public Hashtable oldLineasAfn = new Hashtable();
        public Hashtable oldAutomataAfn = new Hashtable();
        public ArrayList EstadosDKeys = new ArrayList();
        public Boolean button6Clicked = false;
        public ArrayList nuevoAlfabeto = new ArrayList();

        public Trace afnt;

        private void afnEstados_Click(object sender, EventArgs e)
        {
            if (afnEstadosClicked)
            {
                afnEstadosClicked = false;
                afnAnimate.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnLineas.Enabled = afnReset.Enabled = true;
                afnDraw.Cursor = inicial;
            }
            else
            {
                afnEstadosClicked = true;
                afnAnimate.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnLineas.Enabled = afnReset.Enabled = false;
                try
                {
                    afnDraw.Cursor = new Cursor("circulo.cur");
                }
                catch (Exception)
                {
                }
            }
        }

        private void afnDraw_Click(object sender, EventArgs e)
        {
            x = ((MouseEventArgs)e).X;
            y = ((MouseEventArgs)e).Y;
            if (afnEstadosClicked)
            {
                State sTemp = new State("S"+contadorEstadosAfn, x, y);
                while (estadosAfn.ContainsKey("S" + contadorEstadosAfn))
                    contadorEstadosAfn++;
                estadosAfn.Add("S" + contadorEstadosAfn, sTemp);
                afnDraw.Refresh();
                dialog d = new dialog("Ingrese el nombre del estado", "S" + contadorEstadosAfn, false, Color.Black);
                d.ShowDialog();
                estadosAfn.Remove("S" + contadorEstadosAfn);
                if (d.isCorrect)
                {
                    String labelEstado = d.text;
                    Boolean isFinal = d.isFinal;
                    Color colorEstado = d.color;
                    State s = new State(labelEstado, x, y);
                    if (contadorEstadosAfn == 0)
                        s.isInitial = true;
                    s.color = colorEstado;
                    s.isFinal = isFinal;
                    try
                    {
                        estadosAfn.Add(labelEstado, s);
                        contadorEstadosAfn++;
                    }
                    catch (Exception) {
                        s.isInitial = ((State)estadosAfn[labelEstado]).isInitial;
                        estadosAfn.Remove(labelEstado);
                        estadosAfn.Add(labelEstado, s);
                    }
                    
                }
                afnEstados.PerformClick();
                afnDraw.Refresh();
            }
            if (ptoIntermedioClicked)
            {
                labelDest = clickEstadoAfn(x, y);
                if (labelDest != null)
                {
                    dialogLine dl = new dialogLine("Ingrese el caracter del arco", true, true);
                    dl.ShowDialog();
                    if (dl.isAfnCorrect)
                    {
                        String caracter = dl.text;
                        Line lineaAfn = new Line(((State)estadosAfn[labelSource]), ((State)estadosAfn[labelDest]), interX, interY);
                        lineaAfn.label = caracter;
                        lineaAfn.color = dl.color;
                        if (!(lineasAfn.ContainsKey(labelSource + ":" + caracter)))
                        {
                            Hashtable destinos = new Hashtable();
                            destinos.Add(labelDest, lineaAfn);
                            lineasAfn.Add(labelSource + ":" + caracter, destinos);
                        }
                        else
                        {
                            Hashtable temporal = (Hashtable)lineasAfn[labelSource + ":" + caracter];
                            if (!(temporal.ContainsKey(labelDest)))
                            {
                                temporal.Add(labelDest, lineaAfn);
                            }
                            else
                            {
                                temporal.Remove(labelDest);
                                temporal.Add(labelDest, lineaAfn);
                            }

                        }
                        afnDraw.Refresh();
                        ptoIntermedioClicked = false;
                        afnLineas.PerformClick();
                        return;
                    }
                    else
                        afnLineas.PerformClick();
                }
                else
                    afnLineas.PerformClick();
            }
            if (estadoSourceClicked)
            {
                String temp=clickEstadoAfn(x,y);
                if (temp == null)
                {
                    interX = x;
                    interY = y;
                    ptoIntermedioClicked = true;
                    estadoSourceClicked = false;
                }
                return;
            }
            if (afnLineasClicked)
            {
                labelSource = clickEstadoAfn(x, y);
                if (labelSource != null)
                {
                    estadoSourceClicked = true;
                }
            }
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                if (afnDeleteClicked)
                {
                    String estadoABorrar = clickEstadoAfn(x, y);
                    if (estadoABorrar != null)
                    {
                        if (((State)estadosAfn[estadoABorrar]).isInitial)
                        {
                            MessageBox.Show("El estado inicial no puede ser borrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            afnBorrar.PerformClick();
                            return;
                        }

                        DialogResult resultado = MessageBox.Show("Esta seguro que desea eliminar el estado " + estadoABorrar + " ?", "Eliminacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        ArrayList lineasABorrar = new ArrayList();
                        if (resultado == DialogResult.OK)
                        {
                            foreach (DictionaryEntry d in lineasAfn)
                            {
                                ArrayList destinosABorrar = new ArrayList();
                                String[] key = breakKey((String)d.Key);
                                if (key[0] == estadoABorrar)
                                {
                                    lineasABorrar.Add((String)d.Key);
                                }
                                foreach (DictionaryEntry d2 in ((Hashtable)d.Value))
                                {
                                    if ((String)d2.Key == estadoABorrar)
                                        destinosABorrar.Add((String)d2.Key);
                                }
                                foreach (String d3 in destinosABorrar)
                                {
                                    ((Hashtable)d.Value).Remove(d3);
                                }
                                if (((Hashtable)d.Value).Count == 0)
                                    lineasABorrar.Add((String)d.Key);
                            }
                            foreach (String d4 in lineasABorrar)
                            {
                                lineasAfn.Remove(d4);
                            }
                            estadosAfn.Remove(estadoABorrar);
                            afnBorrar.PerformClick();
                            afnDraw.Refresh();
                        }
                        else
                            afnBorrar.PerformClick();
                    }
                }
            }
            if (estadoSourceABorrarClicked)
            {
                String labelDestABorrar = clickEstadoAfn(x, y);
                if (labelDestABorrar != null)
                {
                    int contador = 0;
                    foreach (DictionaryEntry d in lineasAfn)
                    {
                        String[] s = breakKey((String)d.Key);
                        if ( (s[0] == labelSourceABorrar) && ( ((Hashtable)d.Value).ContainsKey(labelDestABorrar)) )
                            contador++;
                    }
                    if (contador != 1)
                    {
                        dialogLine dl = new dialogLine("Ingrese el caracter del Arco a Borrar", false, false);
                        dl.ShowDialog(this);
                        if (dl.isAfnCorrect)
                        {
                            if (lineasAfn.ContainsKey(labelSourceABorrar + ":" + dl.text))
                            {
                                if (((Hashtable)lineasAfn[labelSourceABorrar + ":" + dl.text]).ContainsKey(labelDestABorrar))
                                    ((Hashtable)lineasAfn[labelSourceABorrar + ":" + dl.text]).Remove(labelDestABorrar);
                            }
                        }
                    }
                    else
                    {
                        foreach (DictionaryEntry d2 in lineasAfn)
                        {
                            String[] s = breakKey((String)d2.Key);
                            if ((s[0] == labelSourceABorrar) && (((Hashtable)d2.Value).ContainsKey(labelDestABorrar)))
                                ((Hashtable)d2.Value).Remove(labelDestABorrar);
                        }
                    }
                    ArrayList lineasToRemove = new ArrayList();
                    foreach (DictionaryEntry de in lineasAfn)
                    {
                        if (((Hashtable)de.Value).Count == 0)
                            lineasToRemove.Add((String)de.Key);
                    }
                    foreach (String ltr in lineasToRemove)
                    {
                        lineasAfn.Remove(ltr);
                    }

                    afnBorrar.PerformClick();
                    afnDraw.Refresh();
                }
            }
            if (afnDeleteClicked)
            {
                labelSourceABorrar = clickEstadoAfn(x, y);
                if (labelSourceABorrar != null)
                    estadoSourceABorrarClicked = true;
            }
        }

        private void afnDraw_Paint(object sender, PaintEventArgs e)
        {
            if (button6Clicked)
            {
             //   oldAutomataAfn = (Hashtable)automataAfn.Clone();
             //   oldEstadosAfn = (Hashtable)estadosAfn.Clone();
             //   oldLineasAfn = (Hashtable)lineasAfn.Clone();
                if (afnminimizaclicked)
                {
                    if (afnetapasCounterTD == 0)
                    {
                        afntopleft.Enabled = afnleft.Enabled = false;
                        afntopright.Enabled = afnright.Enabled = true;
                        afnclose.Enabled = true;
                    }
                    else
                    {
                        if (afnetapasCounterTD == (afnetapasMinimizacionTD.Count - 1))
                        {
                            afntopleft.Enabled = afnleft.Enabled = true;
                            afntopright.Enabled = afnright.Enabled = false;
                            afnclose.Enabled = true;
                        }
                        else
                        {
                            afntopleft.Enabled = afnleft.Enabled = afntopright.Enabled = afnright.Enabled = true;
                            afnclose.Enabled = false;
                        }
                    }


                    Hashtable paraActualizar = (Hashtable)afnetapasMinimizacionTD[afnetapasCounterTD];
                    estadosAfn = (Hashtable)paraActualizar["estados"];
                    lineasAfn = (Hashtable)paraActualizar["lineas"];
                    automataAfn = (Hashtable)paraActualizar["automata"];

                    if (automataAfn.Count == 0)
                        afnAnimate.Enabled = false;
                    else
                        afnAnimate.Enabled = true;

                    afnlabel2.Text = (String)afnetapasMinimizacionExplicacionTD[afnetapasCounterTD];

                }
             /*   else
                {
                    automataAfn = automataNuevoAfd;
                    estadosAfn = EstadosDAfd;
                    lineasAfn = lineasNuevasAfd;
                }*/
            }

            int x = 0, y = 0;
            Pen pencil = new Pen(Color.Black, 2);
            Font font = new Font("Arial", 10);
            SolidBrush brush = new SolidBrush(Color.Black);
            AdjustableArrowCap aac = new AdjustableArrowCap(5, 5, true);
            pencil.CustomEndCap = aac;
            foreach (DictionaryEntry d in estadosAfn)
            {
                pencil.Width = 2;
                x = ((State)d.Value).x;
                y = ((State)d.Value).y;
                if (((State)d.Value).isActualState)
                {
                    pencil.Color = Color.Blue;
                    brush.Color = Color.Blue;
                }
                else
                {
                    pencil.Color = ((State)d.Value).color;
                    brush.Color = ((State)d.Value).color;
                }

                gafn.DrawString((String)d.Key, font, brush, x + 5, y + 8);

                if (((State)d.Value).isFinal)
                {
                    pencil.Width = 2;
                    gafn.DrawEllipse(pencil, x, y, 30, 30);
                    pencil.Width = 3;
                    gafn.DrawEllipse(pencil, x - 4, y - 4, 38, 38);
                }
                else
                    gafn.DrawEllipse(pencil, x, y, 30, 30);
                if (((State)d.Value).isInitial)
                {
                    Point[] p = new Point[3];
                    p[2].X = ((State)d.Value).x;
                    p[2].Y = ((State)d.Value).y + 15;
                    p[1].X = ((State)d.Value).x - 15;
                    p[1].Y = ((State)d.Value).y;
                    p[0].X = ((State)d.Value).x - 30;
                    p[0].Y = ((State)d.Value).y - 5;
                    gafn.DrawCurve(pencil, p);
                }
            }
            pencil.Width = 2;
            foreach (DictionaryEntry d in lineasAfn)
            {
                String[] s = breakKey((String)d.Key);
                int sourceX = ((State)estadosAfn[s[0]]).x;
                int sourceY = ((State)estadosAfn[s[0]]).y;
                foreach (DictionaryEntry d2 in (Hashtable)d.Value)
                {
                    int destX = ((State)estadosAfn[(String)d2.Key]).x;
                    int destY = ((State)estadosAfn[(String)d2.Key]).y;
                    int interX = ((Line)d2.Value).intermediatePointX;
                    int interY = ((Line)d2.Value).intermediatePointY;

                    int dxSource = interX - sourceX;
                    int dxDest = interX - destX;
                    int dySource = interY - sourceY;
                    int dyDest = interY - destY;
                    Point[] p = new Point[3];
                    p[1] = new Point(interX, interY);
                    if (Math.Abs(dxSource) < Math.Abs(dySource))
                        if (dySource > 0)
                            p[0] = new Point((sourceX + 15), (sourceY + 30));
                        else
                            p[0] = new Point((sourceX + 15), sourceY);
                    else
                        if (dxSource > 0)
                        p[0] = new Point((sourceX + 30), (sourceY + 15));
                    else
                        p[0] = new Point(sourceX, sourceY + 15);

                    if (Math.Abs(dxDest) < Math.Abs(dyDest))
                        if (dyDest > 0)
                            p[2] = new Point((destX + 15), (destY + 30));
                        else
                            p[2] = new Point((destX + 15), destY);
                    else
                        if (dxDest > 0)
                        p[2] = new Point((destX + 30), (destY + 15));
                    else
                        p[2] = new Point(destX, (destY + 15));

                    if (s[0] == (String)d2.Key)
                    {
                        if (interX < sourceX)
                            if (interY < sourceY)
                            {
                                p[0] = new Point(sourceX, sourceY + 15);
                                p[2] = new Point(destX + 15, destY);
                            }
                            else
                            {
                                p[0] = new Point(sourceX, sourceY + 15);
                                p[2] = new Point(destX + 15, destY + 30);
                            }
                        if (interX > sourceX)
                            if (interY < sourceY)
                            {
                                p[0] = new Point(sourceX + 30, sourceY + 15);
                                p[2] = new Point(destX + 15, destY);
                            }
                            else
                            {
                                p[0] = new Point(sourceX + 30, sourceY + 15);
                                p[2] = new Point(destX + 15, destY + 30);
                            }
                    }
                    if (((Line)d2.Value).isActualLine)
                    {
                        pencil.Color = Color.Blue;
                        brush.Color = Color.Blue;
                    }
                    else
                    {
                        pencil.Color = ((Line)d2.Value).color;
                        brush.Color = ((Line)d2.Value).color;
                    }
                    gafn.DrawCurve(pencil, p);
                    if (((Line)d2.Value).label != "")
                    {
                        Font f = new Font("Arial", 10, FontStyle.Bold);
                        gafn.DrawString(((Line)d2.Value).label, f, brush, p[1].X - 15, p[1].Y - 15);
                    }
                    else
                    {
                        Font f = new Font("Symbol", 10, FontStyle.Bold);
                        gafn.DrawString("l", f, brush, p[1].X - 15, p[1].Y - 15);
                    }
                }
            }
        }

        public String clickEstadoAfn(int x, int y)
        {
            int dx,dy;
            foreach (DictionaryEntry d in estadosAfn)
            {
                dx=((State)d.Value).x;
                dy=((State)d.Value).y;
                if ((dx <= x) && (x <= (dx + 30)) && (dy <= y) && (y <= (dy + 30)))
                    return (String)d.Key;
            }
            return null;
        }

        private void afnDraw_DoubleClick(object sender, EventArgs e)
        {
            String estadoACambiar=clickEstadoAfn(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            if (estadoACambiar!= null) 
            {
                dialog dialogo = new dialog("Ingrese el nombre del estado a editar", estadoACambiar, ((State)estadosAfn[estadoACambiar]).isFinal, ((State)estadosAfn[estadoACambiar]).color);
                dialogo.ShowDialog();
                if (dialogo.isCorrect)
                {
                    String labelEstado = dialogo.text;
                    Boolean isFinal = dialogo.isFinal;
                    Color colorEstado = dialogo.color;
                    State s = (State)estadosAfn[estadoACambiar];                    
                    s.color = colorEstado;
                    s.isFinal = isFinal;
                    s.label = labelEstado;
                    estadosAfn.Remove(estadoACambiar);
                    estadosAfn.Add(labelEstado, s);

                    //actualizar todas las lineas que tienen como estado source al estado cambiado
                    if (estadoACambiar != labelEstado)
                    {
                        ArrayList KeyToRemove = new ArrayList();
                        ArrayList KeyToUpdate = new ArrayList();

                        foreach (DictionaryEntry de in lineasAfn)
                        {
                            String[] toCheck = breakKey((String)de.Key);
                            if (toCheck[0] == estadoACambiar)
                            {
                                KeyToRemove.Add((String)de.Key);
                                KeyToUpdate.Add(labelEstado + ":" + toCheck[1]);
                            }
                            if (((Hashtable)de.Value).ContainsKey(estadoACambiar))
                            {
                                ((Hashtable)de.Value).Add(labelEstado, (Line)(((Hashtable)de.Value)[estadoACambiar]));
                                ((Hashtable)de.Value).Remove(estadoACambiar);
                            }
                            ArrayList lineasToUpdate = new ArrayList();

                            foreach (DictionaryEntry de2 in ((Hashtable)de.Value))
                            {
                                Line l = (Line)de2.Value;
                                if (l.label == estadoACambiar)
                                    lineasToUpdate.Add((String)de2.Key);
                            }
                            foreach (String key in lineasToUpdate)
                            {
                                ((Line)((Hashtable)de.Value)[key]).label = labelEstado;
                            }
                        }

                        for (int i = 0; i < KeyToRemove.Count; i++)
                        {
                            Hashtable lineHtToUpdate = (Hashtable)lineasAfn[KeyToRemove[i]];
                            lineasAfn.Add(KeyToUpdate[i], lineHtToUpdate);
                            lineasAfn.Remove(KeyToRemove[i]);
                        }
                    }

                }                
                afnDraw.Refresh();
            }
        }

        private void afnLineas_Click(object sender, EventArgs e)
        {
            if (afnLineasClicked)
            {
                afnLineasClicked = false;
                afnAnimate.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnEstados.Enabled = afnReset.Enabled = true;
                ptoIntermedioClicked = estadoSourceClicked = false;
                interX = interY = 0;
                labelSource = "";
                labelDest = "";
            }
            else
            {
                afnLineasClicked = true;
                afnAnimate.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnEstados.Enabled = afnReset.Enabled = false;
            }
        }

        private void afnBorrar_Click(object sender, EventArgs e)
        {
            if (afnDeleteClicked)
            {
                afnDeleteClicked = false;
                afnAnimate.Enabled = afnLineas.Enabled = afnLimpiar.Enabled = afnEstados.Enabled = afnReset.Enabled = true;
                estadoSourceABorrarClicked = false;
                labelSourceABorrar = "";
            }
            else
            {
                afnDeleteClicked = true;
                afnAnimate.Enabled = afnLineas.Enabled = afnLimpiar.Enabled = afnEstados.Enabled = afnReset.Enabled = false;
            }
        }

        private void afnLimpiar_Click(object sender, EventArgs e)
        {
            estadosAfn.Clear();
            lineasAfn.Clear();
            afnDraw.Refresh();
            contadorEstadosAfn = 0;
        }

        public void llenarAutomataAfn()
        {
            automataAfn.Clear();
            foreach (DictionaryEntry d in lineasAfn)
            {
                ArrayList destinos = new ArrayList();
                foreach (DictionaryEntry d2 in ((Hashtable)d.Value))
                {
                    destinos.Add((String)d2.Key);
                }
                automataAfn.Add((String)d.Key, destinos);
            }
        }

        private void afnAnimate_Click(object sender, EventArgs e)
        {
            if (afnAnimateClicked)
            {
                afnAnimateClicked = false;
                afnEstados.Enabled = afnLineas.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnReset.Enabled = true;
                afnTimer.Stop();
                foreach (DictionaryEntry de in lineasAfn)
                {
                    foreach (DictionaryEntry de2 in (Hashtable)de.Value)
                    {
                        Line l = (Line)de2.Value;
                        if (l.isActualLine)
                            l.isActualLine = false;
                    }
                }
                foreach (DictionaryEntry de in estadosAfn)
                {
                    State s = (State)de.Value;
                    if (s.isActualState)
                        s.isActualState = false;
                }
                textBox2.ReadOnly = panel5.Visible = false;
                afnTextInput = "";
                afnDraw.Refresh();
            }
            else
            {
                llenarAutomataAfn();
                afnAnimateClicked = true;
                afnlastActualLineKey = "";
                afnlastActualLineHtKey = "";
                panel5.Visible = true;
                afncharInString = 0;
                afnEstados.Enabled = afnLineas.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnReset.Enabled = false;
                afnTextInput = textBox2.Text;
                foreach (DictionaryEntry de in estadosAfn)
                {
                    if (((State)de.Value).isInitial)
                    {
                        afnactualState = afnInitialState = ((State)de.Value).label;
                        break;
                    }
                }
                State actual = (State)estadosAfn[afnactualState];
                afnt = new Trace(afnTextInput);
                afnt.Show();
                afnt.refresh(afnactualState + " ");
                actual.isActualState = true;
                afnDraw.Refresh();
                textBox2.ReadOnly = true;
                afnTimer.Start();
            }
        }

        private void afnTimer_Tick(object sender, EventArgs e)
        {
            String nextChar = "";
            State actual = (State)estadosAfn[afnactualState];
            actual.isActualState = true;
            afnDraw.Refresh();
            try
            {
                nextChar = "" + afnTextInput[afnTextInputCounter];
            }
            catch (Exception)
            {
                ArrayList closure = getClosure(afnactualState);
                if (closure.Count > 0)
                {
                    Hashtable closureHT = new Hashtable();
                    foreach (String estado in closure)
                    {
                        closureHT.Add(estado + " con lambda", estado + ":");
                    }
                    closureHT.Add("Quedarse en estado " + afnactualState, afnactualState + ":");
                    String nuevoEstadoTransition = escogerEstado("", closureHT);
                    String nuevoEstado;
                    if ((nuevoEstadoTransition != "") && ((nuevoEstado = (breakKey(nuevoEstadoTransition))[0]) != afnactualState))
                    {
                        Line l = (Line)((Hashtable)lineasAfn[afnactualState + ":" + nextChar])[nuevoEstado];
                        if ((afnlastActualLineKey != "") && (afnlastActualLineHtKey != ""))
                        {
                            Line l2 = (Line)((Hashtable)lineasAfn[afnlastActualLineKey])[afnlastActualLineHtKey];
                            l2.isActualLine = false;
                        }
                        afnlastActualLineKey = afnactualState + ":" + nextChar;
                        afnlastActualLineHtKey = nuevoEstado;
                        l.isActualLine = true;
                        afnactualState = nuevoEstado;
                        State state = (State)estadosAfn[afnactualState];
                        state.isActualState = true;
                        afnDraw.Refresh();
                        afnt.refresh(", lambda --> " + afnactualState);
                        return;
                    }
                    else
                    {
                        if (nuevoEstadoTransition == "")
                        {
                            afnAnimate.PerformClick();
                            afnTimer.Stop();
                        }
                    }
                }

                if (((State)estadosAfn[afnactualState]).isFinal)
                {
                    afnTimer.Stop();
                    afnTextInputCounter = 0;
                    State finalStateChecked = (State)estadosAfn[afnactualState];
                    finalStateChecked.isActualState = false;
                    MessageBox.Show("CUERDA ACEPTADA!", "Aceptada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afnDraw.Refresh();
                    afnAnimate.PerformClick();
                } else
                {
                    afncuerdaNoAceptada();
                }
                return;
            }
            afncharInString = afnTextInputCounter;
            panel5.Refresh();

            if (automataAfn.Contains(afnactualState + ":" + nextChar))
            {
                State s = (State)estadosAfn[afnactualState];
                s.isActualState = false;
                ArrayList aEscoger = getClosure(afnactualState);
                Hashtable aEscogerHT = new Hashtable();
                foreach (String saEscoger in aEscoger)
                {
                    aEscogerHT.Add(saEscoger + " con lambda", saEscoger + ":");
                }
                foreach (String state in (ArrayList)automataAfn[afnactualState + ":" + nextChar])
                {
                    aEscogerHT.Add(state + " con " + nextChar, state + ":" + nextChar);
                }

                String nuevoEstadoTransition;
                if (aEscogerHT.Count > 1)
                    nuevoEstadoTransition = escogerEstado(nextChar, aEscogerHT);
                else
                    nuevoEstadoTransition = (String)((ArrayList)automataAfn[afnactualState + ":" + nextChar])[0] + ":" + nextChar;
                if (nuevoEstadoTransition != "")
                {
                    nextChar = (breakKey(nuevoEstadoTransition))[1];
                    String nuevoEstado = (breakKey(nuevoEstadoTransition))[0];
                    String aEscribirEnTrace = "";
                    if (nextChar != "")
                    {
                        afnTextInputCounter++;
                        aEscribirEnTrace = nextChar;
                    }
                    else
                    {
                        aEscribirEnTrace = "lambda";
                    }


                    Line l = (Line)((Hashtable)lineasAfn[afnactualState + ":" + nextChar])[nuevoEstado];
                    if ((afnlastActualLineKey != "") && (afnlastActualLineHtKey != ""))
                    {
                        Line l2 = (Line)((Hashtable)lineasAfn[afnlastActualLineKey])[afnlastActualLineHtKey];
                        l2.isActualLine = false;
                    }
                    afnlastActualLineKey = afnactualState + ":" + nextChar;
                    afnlastActualLineHtKey = nuevoEstado;

                    l.isActualLine = true;
                    afnactualState = nuevoEstado;
                    State s2 = (State)estadosAfn[afnactualState];
                    s2.isActualState = true;
                    afnt.refresh(", " + aEscribirEnTrace + " --> " +  afnactualState);
                }
                else
                {
                    if (nuevoEstadoTransition == "")
                    {
                        afnAnimate.PerformClick();
                        afnTimer.Stop();
                    }
                }
            }
            else
            {
                ArrayList closure = getClosure(afnactualState);
                if (closure.Count > 0)
                {
                    Hashtable closureHT = new Hashtable();
                    foreach (String s in closure)
                    {
                        closureHT.Add(s + " con lambda", s + ":");
                    }
                    String nuevoEstadoTransition;
                    if (closureHT.Count > 1)
                        nuevoEstadoTransition = escogerEstado("", closureHT);
                    else
                        nuevoEstadoTransition = closure[0] + ":";
                    String nuevoEstado;
                    nextChar = "";
                    if ((nuevoEstadoTransition != "") && ((nuevoEstado = (breakKey(nuevoEstadoTransition))[0]) != afnactualState))
                    {
                        Line l = (Line)((Hashtable)lineasAfn[afnactualState + ":" + nextChar])[nuevoEstado];
                        if ((afnlastActualLineKey != "") && (afnlastActualLineHtKey != ""))
                        {
                            Line l2 = (Line)((Hashtable)lineasAfn[afnlastActualLineKey])[afnlastActualLineHtKey];
                            l2.isActualLine = false;
                        }
                        afnlastActualLineKey = afnactualState + ":" + nextChar;
                        afnlastActualLineHtKey = nuevoEstado;


                        l.isActualLine = true;
                        afnactualState = nuevoEstado;
                        State state = (State)estadosAfn[afnactualState];
                        state.isActualState = true;
                        afnt.refresh(", lambda --> " + afnactualState);
                        afnDraw.Refresh();
                        return;
                    }
                    else
                    {
                        if (nuevoEstadoTransition == "")
                        {
                            afnAnimate.PerformClick();
                            afnTimer.Stop();
                        }
                    }
                }
                afncuerdaNoAceptada();
            }
            afnDraw.Refresh();
        }

        public void afncuerdaNoAceptada()
        {
            afnTextInputCounter = 0;
            State finalStateChecked = (State)estadosAfn[afnactualState];
            finalStateChecked.isActualState = false;
            afnTimer.Stop();
            afnDraw.Refresh();
            afnt.refresh(" --> XX <-- ");
            MessageBox.Show("CUERDA INGRESADA NO ACEPTADA POR EL AUTOMATUM!", "cuerda no aceptada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            afnAnimate.PerformClick();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            int xInicial = (int)((850 / 2) - (afnTextInput.Length * 5));
            Graphics gCuerda = panel5.CreateGraphics();
            SolidBrush sd = new SolidBrush(Color.Black);
            Font f = new Font("Tahoma", 20);
            for (int i = 0; i < afnTextInput.Length; i++)
            {
                if (i == afncharInString)
                    sd.Color = Color.Blue;
                else
                    sd.Color = Color.Black;
                gCuerda.DrawString("" + afnTextInput[i], f, sd, xInicial + 5 + (i * 13), 5);
            }
        }

        public ArrayList getClosure(String index)
        {
            foreach (DictionaryEntry de in automataAfn)
            {
                if ((String)de.Key == (index + ":"))
                    return (ArrayList)de.Value;
            }
            return new ArrayList();
        }

        public String escogerEstado(String caracter, Hashtable paraEscoger)
        {
            EscogerEstado ee = new EscogerEstado(caracter, paraEscoger);
            afnTimer.Stop();
            ee.ShowDialog();
            afnTimer.Start();
            return ee.estadoEscogido;
        }

        private void afnmatricial_Click(object sender, EventArgs e)
        {
            afnmatricial.Refresh();
        }

        private void afnmatricial_Paint(object sender, PaintEventArgs e)
        {
            gafn2 = e.Graphics;
            gafn2.TranslateTransform(afnmatricial.AutoScrollPosition.X, afnmatricial.AutoScrollPosition.Y);

            Pen pencil = new Pen(Color.Black, 2);
            Font font = new Font("Arial", 13);
            Font font2 = new Font("Arial", 15, FontStyle.Bold);
            Font font3 = new Font("Symbol", 15, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush brush2 = new SolidBrush(Color.Blue);
            ArrayList alfabetoAfn = new ArrayList();
            /*Point A = new Point();
            Point B = new Point();*/
            int j, x, y, w, z = 0;
            llenarAutomataAfn();

            Size scrollOffset = new Size(afnmatricial.AutoScrollPosition);

            foreach (DictionaryEntry de in automataAfn)
            {
                String[] keys = breakKey((String)de.Key);
                if (!alfabetoAfn.Contains(keys[1]))
                    alfabetoAfn.Add(keys[1]);
            }


            int a = alfabetoAfn.Count;
            int s = estadosAfn.Count;
            int d = (a / 2) + 1;
            int temp1 = 876;
            int temp2 = 586;

            if ((a > 6) && (s > 12))
            {
                afnmatricial.Size = new Size((temp1 + ((a - 6) * 75)), (temp2 + ((s - 12) * 40)));
            }
            else
            {
                if (a > 6)
                    afnmatricial.Size = new Size((temp1 + ((a - 6) * 75)), temp2);
                if (s > 12)
                    afnmatricial.Size = new Size(temp1, (temp2 + ((s - 12) * 40)));
            }



            x = (afnmatricial.Size.Width / 2) - 100 - (d * 75);
            y = 50;
            w = ((a + 1) * 100);
            z = ((s + 1) * 40);

            gafn2.DrawRectangle(pencil, x + scrollOffset.Width, y + scrollOffset.Height, w, z);
            w = w + x;
            z = z + y;
            j = x + 45;

            for (int i = 0; i <= (a - 1); i++)
            {
                j += 100;
                if ((String)alfabetoAfn[i] != "")
                    gafn2.DrawString((String)alfabetoAfn[i], font2, brush, new Point(j + scrollOffset.Width, (y + 8) + scrollOffset.Height));
                else
                    gafn2.DrawString("l", font3, brush, new Point(j + scrollOffset.Width, (y + 8) + scrollOffset.Height));
                x += 100;
                w = x;
                gafn2.DrawLine(pencil, new Point(x + scrollOffset.Width, y + scrollOffset.Height), new Point(w + scrollOffset.Width, z + scrollOffset.Height));

            }
            x = (afnmatricial.Size.Width / 2) - 100 - (d * 75);
//            foreach (DictionaryEntry de in estados)
            String[] keysEstados = ordenarAfn();
            for (int i = 0; i < keysEstados.Length; i++)
            {
                //String s2 = (String)de.Key;
                //State s3 = (State)de.Value;
                String s2 = keysEstados[i];
                State s3 = (State)estadosAfn[keysEstados[i]];
                y = y + 40;
                if (!(s3.isFinal))
                    gafn2.DrawString(s2, font2, brush, new Point((x + 25) + scrollOffset.Width, (y + 8) + scrollOffset.Height));
                else
                    gafn2.DrawString(s2, font2, brush2, new Point((x + 25) + scrollOffset.Width, (y + 8) + scrollOffset.Height));
                w = x + ((a + 1) * 100);
                z = y;
                gafn2.DrawLine(pencil, new Point(x + scrollOffset.Width, y + scrollOffset.Height), new Point(w + scrollOffset.Width, z + scrollOffset.Height));
            }

            String clave;
            y = 80;
//            foreach (DictionaryEntry de in estados)
            for (int k = 0; k < keysEstados.Length; k++)
            {
                x = (afnmatricial.Size.Width / 2) - (d * 75);
                //String s2 = (String)de.Key;
                String s2 = keysEstados[k];
                for (int i = 0; i <= (a - 1); i++)
                {
                    clave = s2 + ":" + (String)alfabetoAfn[i];
                    ArrayList destinos = (ArrayList)automataAfn[clave];
                    if (destinos != null)
                    {
                        String destino = "";
                        foreach (String dest in destinos)
                            destino = destino + " " + dest;
                        gafn2.DrawString(destino, font, brush, new Point((x + 10) + scrollOffset.Width, (y + 20) + scrollOffset.Height));
                    }
                    else
                    {
                        gafn2.DrawString("XX", font, brush, new Point((x + 25) + scrollOffset.Width, (y + 20) + scrollOffset.Height));
                    }

                    x += 100;
                }
                y += 40;
            }
        }

        private void afnmatricial_Scroll(object sender, ScrollEventArgs e)
        {
            afnmatricial.Refresh();
        }

        public ArrayList getClosureD(ArrayList cambiosDelClosure)
        {
            ArrayList nuevoClosure=new ArrayList();
            foreach (String keyClosure in cambiosDelClosure)
            {
                nuevoClosure.Add(keyClosure);
                ArrayList tempClosure = closureD(keyClosure,(ArrayList)nuevoClosure.Clone());
                foreach (String tempC in tempClosure)
                    if (!nuevoClosure.Contains(tempC))
                        nuevoClosure.Add(tempC);
            }
            return nuevoClosure;
        }

        public ArrayList closureD(String key, ArrayList estadosClosure)
        {
            if (automataAfn.ContainsKey(key + ":"))
            {
                foreach (String keys in (ArrayList)automataAfn[key + ":"])
                {
                    if (!estadosClosure.Contains(keys))
                    {
                        estadosClosure.Add(keys);
                        estadosClosure = closureD(keys, estadosClosure);
                    }
                }
            }
            return estadosClosure;
        }

        public ArrayList getTranD(String caracter, ArrayList clausura)
        {
            ArrayList tranD = new ArrayList();
            foreach (String s in clausura)
            {
                if (automataAfn.ContainsKey(s + ":" + caracter))
                {
                    foreach (String toAdd in ((ArrayList)automataAfn[s + ":" + caracter]))
                    {
                        if (!tranD.Contains(toAdd))
                        {
                            tranD.Add(toAdd);
                        }
                    }
                }
            }
            return tranD;
        }
        private Boolean EstadosDIguales(Hashtable estadosD, ArrayList prospecto)
        {
            foreach (DictionaryEntry d in estadosD)
            {
                Boolean siContiene = true;
                foreach (String s in prospecto)
                {
                    if (  (!(((ArrayList)d.Value).Contains(s))) || (((ArrayList)d.Value).Count != prospecto.Count) )
                        siContiene = false;
                }
                if (siContiene)
                    return true;
            }
            return false;
        }

        private String getKey(Hashtable estadosD, ArrayList prospecto)
        {
            foreach (DictionaryEntry d in estadosD)
            {
                Boolean siContiene = true;
                foreach (String s in prospecto)
                {
                    if ((!(((ArrayList)d.Value).Contains(s))) || (((ArrayList)d.Value).Count != prospecto.Count))
                        siContiene = false;
                }
                if (siContiene)
                    return (String)d.Key;
            }
            return "";
        }

        private void llenarEstadosDAfd()
        {
            int numEstados = EstadosD.Count;
            int numLetras = nuevoAlfabeto.Count;
            int x = 0;
            int y = 0;


            foreach (DictionaryEntry d in EstadosD)
            {
                int contadorX = 0;
                int contadorY = 0;
                Boolean isFinal = false;
                foreach (String estado in (ArrayList)d.Value)
                {
                    contadorX += ((State)estadosAfn[estado]).x;
                    contadorY += ((State)estadosAfn[estado]).y;
                    if (((State)estadosAfn[estado]).isFinal)
                        isFinal = true;

                }
                x = contadorX / ((ArrayList)d.Value).Count;
                y = contadorY / ((ArrayList)d.Value).Count;
                State nuevoEstado;
                if (!checkPoints(x, y))
                    nuevoEstado = new State((String)d.Key, x, y);
                else
                    nuevoEstado = new State((String)d.Key, x + 90, y + 90);
                nuevoEstado.isFinal = isFinal;
                if ((string)d.Key == "A")
                    nuevoEstado.isInitial = true;
                EstadosDAfd.Add((String)d.Key, nuevoEstado);
            }
        }

        private Boolean checkPoints(int x, int y)
        {
            int dx, dy;
            foreach (DictionaryEntry d in estadosAfn)
            {
                dx = ((State)d.Value).x;
                dy = ((State)d.Value).y;
                if ((dx <= (x-30)) && (x <= (dx + 60)) && (dy <= (y-30)) && (y <= (dy + 60)))
                    return true;
            }
            return false;
        }

        private void llenarLineasAfd()
        {
            lineasNuevasAfd = new Hashtable();
            Hashtable linesAdded = new Hashtable();
            foreach (DictionaryEntry d in automataNuevoAfd)
            {
                String[] sourceKey = breakKey((String)d.Key);
                String destKey = (String)(((ArrayList)d.Value)[0]);
                State si = (State)EstadosDAfd[sourceKey[0]];
                State sj = (State)EstadosDAfd[destKey];

       /*         int imx;
                int imy;
                int dy = sj.y - si.y;
                int dx = sj.x - si.x;
                imy = si.y + (dy / 2);
                imx = si.x + (dx / 2);

                if (si.label == sj.label)
                {
                    imx = si.x + 50;
                    imy = si.y - 20;
                    if (!linesAdded.ContainsKey(si.label + si.label))
                        linesAdded.Add(si.label + si.label, 1);
                    else
                    {
                        int toAdd = (int)linesAdded[si.label + si.label];
                        imy -= toAdd;
                        linesAdded.Remove(si.label + si.label);
                        linesAdded.Add(si.label + si.label, (++toAdd));
                    }
                }*/

                int imx;
                int imy;
                int dy = sj.y - si.y;
                int dx = sj.x - si.x;
                imy = si.y + (dy / 2);
                imx = si.x + (dx / 2);
                if (!linesAdded.ContainsKey(si.label))
                {
                    linesAdded.Add(si.label, 1);
                }
                else
                {
                    int toAdd = (int)linesAdded[si.label];
                    imy -= toAdd * 35;
                    linesAdded.Remove(si.label);
                    linesAdded.Add(si.label, (++toAdd));
                }
                if (!linesAdded.ContainsKey(sj.label))
                    linesAdded.Add(sj.label, 1);
                else
                {
                    int toAdd = (int)linesAdded[sj.label] + 1;
                    linesAdded.Remove(sj.label);
                    linesAdded.Add(sj.label, toAdd);
                }

                if (si.label == sj.label)
                {
                    imx = si.x + 50;
                    imy = si.y - 20;
                    if (!linesAdded.ContainsKey(si.label + si.label))
                        linesAdded.Add(si.label + si.label, 1);
                    else
                    {
                        int toAdd = (int)linesAdded[si.label + si.label];
                        imy -= toAdd;
                        linesAdded.Remove(si.label + si.label);
                        linesAdded.Add(si.label + si.label, (++toAdd));
                    }
                }

                Line linea = new Line(si, sj, imx, imy);
                linea.label = sourceKey[1];
                Hashtable lineaTemp = new Hashtable();
                lineaTemp.Add(destKey, linea);
                lineasNuevasAfd.Add((String)d.Key, lineaTemp);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!button6Clicked)
            {
                AFNtoAFD nToD = new AFNtoAFD();
                nToD.Show();
                button6Clicked = true;
                //afnAnimate.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnLineas.Enabled = afnReset.Enabled = afnEstados.Enabled = false;
                afnReset.Enabled = true;
                oldAutomataAfn = (Hashtable)automataAfn.Clone();
                oldEstadosAfn = (Hashtable)estadosAfn.Clone();
                oldLineasAfn = (Hashtable)lineasAfn.Clone();

                afnminimizar.Visible = true;

                foreach (DictionaryEntry de in estadosAfn)
                {
                    if (((State)de.Value).isInitial)
                    {
                        afnInitialState = ((State)de.Value).label;
                        break;
                    }
                }
                EstadosD = new Hashtable();
                EstadosDKeys = new ArrayList();
                int nuevoContadorAfdEstados = 65;
                ArrayList closure = new ArrayList();
                closure.Add(afnInitialState);
                closure = closureD(afnInitialState, closure);
                EstadosD.Add("" + ((char)(nuevoContadorAfdEstados)), closure);
                EstadosDKeys.Add("" + ((char)(nuevoContadorAfdEstados++)));
                nuevoAlfabeto = new ArrayList();
                llenarAutomataAfn();
                foreach (DictionaryEntry de in automataAfn)
                {
                    String[] keys = breakKey((String)de.Key);
                    if (!nuevoAlfabeto.Contains(keys[1]))
                        if (keys[1] != "")
                            nuevoAlfabeto.Add(keys[1]);
                }
                nToD.refresh("   Closure Inicial : {");
                foreach (String c in closure)
                    nToD.refresh(c + " ");
                nToD.refresh(" } =" + (String)EstadosDKeys[0]);

                automataNuevoAfd = new Hashtable();

                for (int i = 0; i < EstadosDKeys.Count; i++)
                {

                    ArrayList clausura = (ArrayList)EstadosD[EstadosDKeys[i]];

                    foreach (String alfa in nuevoAlfabeto)
                    {
                        ArrayList tranD = getTranD(alfa, clausura);
                        nToD.refresh("\r\n   Cambio (" + EstadosDKeys[i] + " , " + alfa + ")= {");
                        foreach (String td in tranD)
                            nToD.refresh(td + " ");

                        nToD.refresh("} \t Closure de (" + EstadosDKeys[i] + " , " + alfa + ")= {");
                        ArrayList nuevoEstadoD = getClosureD(tranD);
                        if (nuevoEstadoD.Count == 0)
                            nToD.refresh(" }");
                        foreach (String ne in nuevoEstadoD)
                            nToD.refresh(ne + " ");

                        ArrayList estadoToAdd = new ArrayList();
                        if ((!(EstadosDIguales(EstadosD, nuevoEstadoD))) && (nuevoEstadoD.Count > 0))
                        {
                            EstadosD.Add("" + ((char)(nuevoContadorAfdEstados)), nuevoEstadoD);
                            EstadosDKeys.Add("" + ((char)(nuevoContadorAfdEstados)));
                            nToD.refresh("}  = " + ((char)(nuevoContadorAfdEstados)));
                            estadoToAdd.Add("" + ((char)(nuevoContadorAfdEstados++)));
                            automataNuevoAfd.Add(EstadosDKeys[i] + ":" + alfa, estadoToAdd);
                        }
                        else
                        {
                            if (nuevoEstadoD.Count > 0)
                            {
                                estadoToAdd.Add(getKey(EstadosD, nuevoEstadoD));
                                automataNuevoAfd.Add(EstadosDKeys[i] + ":" + alfa, estadoToAdd);
                                nToD.refresh("}  = " + (String)estadoToAdd[0]);
                            }
                        }

                    }

                }
                llenarEstadosDAfd();
                llenarLineasAfd();

                automataAfn = automataNuevoAfd;
                estadosAfn = EstadosDAfd;
                lineasAfn = lineasNuevasAfd;

                afnDraw.Refresh();

            }
            else
            {
                button6Clicked = false;
                //afnAnimate.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnLineas.Enabled = afnReset.Enabled = afnEstados.Enabled = true;
                afnReset.PerformClick();
                afnReset.Enabled = false;
                EstadosDAfd.Clear();
                lineasNuevasAfd.Clear();
                automataNuevoAfd.Clear();
                afnminimizar.Visible = false;
            }
        }

        private void afnReset_Click(object sender, EventArgs e)
        {
            automataAfn = oldAutomataAfn;
            lineasAfn = oldLineasAfn;
            estadosAfn = oldEstadosAfn;
            afnclose.PerformClick();
            afnDraw.Refresh();
        }


        public ArrayList afnetapasMinimizacionTD;
        public ArrayList afnetapasMinimizacionExplicacionTD;
        public int afnetapasCounterTD;
        public ArrayList afnetapasMinimizacionBU;
        public ArrayList afnetapasMinimizacionExplicacionBU;
        public Boolean afnminimizaclicked = false;

        private void afnminimizar_Click(object sender, EventArgs e)
        {
            EscogerAlgoritmo ea = new EscogerAlgoritmo();
            ea.ShowDialog();
            afnEstados.Enabled = afnLineas.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnReset.Enabled = afnminimizar.Enabled = button6.Enabled = false;
            afnetapasCounterTD = 0;
            afnetapasMinimizacionTD = new ArrayList();
            afnetapasMinimizacionExplicacionTD = new ArrayList();
            if (ea.isTopDown)
            {
                afntopDown();
            }
            else
            {
                afnetapasMinimizacionBU = new ArrayList();
                afnetapasMinimizacionExplicacionBU = new ArrayList();
                afnbottomUp();
            }
        }

        public Hashtable oldestadosminimiza = new Hashtable();
        public Hashtable oldlineasminimiza = new Hashtable();
        public Hashtable oldautomataminimiza = new Hashtable();

        private void afnresetminimiza_Click(object sender, EventArgs e)
        {
            if (afnminimizaclicked)
                afnclose.PerformClick();
            
            estadosAfn = oldestadosminimiza;
            llenarAutomataAfn();
            afnDraw.Refresh();
        }

        public Hashtable afdToAfn(Hashtable automataAfd) // convertir de un automata afd a un afn
        {
            Hashtable automataAfn = new Hashtable();
            foreach (DictionaryEntry de in automataAfd)
            {
                ArrayList toAdd = new ArrayList();
                toAdd.Add((String)de.Value);
                automataAfn.Add((String)de.Key, toAdd);
            }
            return automataAfn;
        }

        public Hashtable afnToAfd(Hashtable automataAfn) // convertir de un automata afn a un afd
        {
            Hashtable automataAfd = new Hashtable();
            foreach (DictionaryEntry de in automataAfn)
            {
                automataAfd.Add((String)de.Key, ((ArrayList)de.Value)[0]);
            }
            return automataAfd;
        }

        public Hashtable afdlineasToAfnlineas(Hashtable lineasAfd) // convertir de lineas afd a lineas afn
        {
            Hashtable lineasAfn = new Hashtable();
            foreach (DictionaryEntry de in lineasAfd)
            {
                Hashtable toAdd = new Hashtable();
                toAdd.Add(((Line)de.Value).dest.label, (Line)de.Value);
                lineasAfn.Add((String)de.Key, toAdd);
            }
            return lineasAfn;
        }

        public Hashtable afnlineasToAfdlineas(Hashtable lineasAfn) // convertir de un automata afn a un afd
        {
            Hashtable lineasAfd = new Hashtable();
            foreach (DictionaryEntry de in lineasAfn)
            {
                Line toAdd = null;
                foreach (DictionaryEntry de2 in ((Hashtable)de.Value))
                    toAdd = (Line)de2.Value;
                lineasAfd.Add((String)de.Key, toAdd);
            }
            return lineasAfd;
        }

        public Boolean afnminimizaBUclicked = false;
        public Boolean afnminimizaTDclicked = false;

        public void afnbottomUp()
        {
            oldestadosminimiza = (Hashtable)estadosAfn.Clone();
            oldlineasminimiza  = (Hashtable)lineasAfn.Clone();
            oldautomataminimiza = (Hashtable)automataAfn.Clone();
            Hashtable etapa0 = new Hashtable();
            etapa0.Add("estados", oldestadosminimiza);
            etapa0.Add("lineas", lineasAfn);
            etapa0.Add("automata", oldautomataminimiza);
            afnetapasMinimizacionTD.Add(etapa0);
            afnetapasMinimizacionExplicacionTD.Add("Etapa Inicial");

            afntopleft.Visible = afnleft.Visible = afnclose.Visible = afnright.Visible = afntopright.Visible = afnlabel2.Visible = true;
            afnminimizaclicked = afnminimizaBUclicked = true;
            saveToolStripMenuItem.Enabled = true;

            Hashtable automataAfnminimiza = afnToAfd(automataAfn);
            Hashtable lineasAfnminimiza = afnlineasToAfdlineas(lineasAfn);

            /********************************************************************************************/
            Boolean isChanged = true; // quitar estados inservibles (unreachable)
            while (isChanged)
            {
                isChanged = false;
                Boolean inservible;
                ArrayList estadosInservibles = new ArrayList();

                foreach (DictionaryEntry de in estadosAfn)
                {
                    inservible = true;
                    foreach (DictionaryEntry de2 in automataAfnminimiza)
                    {
                        if (((String)de.Key == (String)de2.Value) && ((breakKey((String)de2.Key))[0] != (String)de.Key))
                        {
                            inservible = false;
                            break;
                        }
                    }
                    if ((inservible) && !((State)de.Value).isInitial)
                    {
                        estadosInservibles.Add((String)de.Key);
                        isChanged = true;
                    }
                }
                ArrayList toRemove = new ArrayList();
                for (int i = 0; i < estadosInservibles.Count; i++)
                {
                    String key = (String)estadosInservibles[i];
                    foreach (DictionaryEntry de in lineasAfnminimiza)
                    {
                        String[] toCheck = breakKey((String)de.Key);
                        if (toCheck[0] == key)
                            toRemove.Add((String)de.Key);
                        if (((Line)de.Value).dest.label == key)
                            toRemove.Add((String)de.Key);
                    }
                    for (int j = 0; j < toRemove.Count; j++)
                    {
                        lineasAfnminimiza.Remove(toRemove[j]);
                        automataAfnminimiza.Remove(toRemove[j]);
                    }
                    estadosAfn.Remove(key);
                    Hashtable etapaInservible = new Hashtable();
                    etapaInservible.Add("estados", (Hashtable)estadosAfn.Clone());
                    etapaInservible.Add("lineas", afnlineasToAfdlineas((Hashtable)lineasAfnminimiza.Clone()));
                    etapaInservible.Add("automata", afnToAfd((Hashtable)automataAfnminimiza.Clone()));
                    afnetapasMinimizacionTD.Add(etapaInservible);
                    afnetapasMinimizacionExplicacionTD.Add("Eliminacion estados Inservibles: Se elimino estado " + key);
                }
            }

            ArrayList alfabeto = new ArrayList(); // sacamos alfabeto
            foreach (DictionaryEntry de in automataAfnminimiza)
            {
                String[] keys = breakKey((String)de.Key);
                if (!alfabeto.Contains(keys[1]))
                    alfabeto.Add(keys[1]);
            }
            State estadoBasura = new State("sBasura", -40, -40);
            estadoBasura.isFinal = false;
            estadosAfn.Add(estadoBasura.label, estadoBasura);

            foreach (DictionaryEntry state in estadosAfn) // llenamos bien la matriz automata
                foreach (String alfa in alfabeto)
                    if (!automataAfnminimiza.Contains((String)state.Key + ":" + alfa))
                        automataAfnminimiza.Add((String)state.Key + ":" + alfa, estadoBasura.label);


            /********************************************************************************************/

            /**********************************************************************************************
             * Comienza algoritmo de minimizacion bottom-up
             **********************************************************************************************/

            String[] keysOrdenados = ordenarAfn();
            ArrayList keysEstados = new ArrayList();
            for (int i = 0; i < keysOrdenados.Length; i++)
                keysEstados.Add(keysOrdenados[i]);

            int iteraciones = 0;
            Hashtable pairTable = crearTabla(keysEstados);
            Hashtable pairTableInicial = new Hashtable();
            int contadorMarked = 1;
            foreach (DictionaryEntry de in pairTable)
            {
                String[] keys = breakKey((String)de.Key);
                if (((State)estadosAfn[keys[0]]).isFinal != ((State)estadosAfn[keys[1]]).isFinal)
                {
                    pairTableInicial.Add((String)de.Key, "X:" + iteraciones);
                    contadorMarked++;
                }
                else
                    pairTableInicial.Add((String)de.Key, "");
            }
            iteraciones++;

            pairTable = (Hashtable)pairTableInicial.Clone();
            afnetapasMinimizacionBU.Add((Hashtable)pairTable.Clone());
            afnetapasMinimizacionExplicacionBU.Add("Pair Table inicial");
            while (contadorMarked > 0)
            {
                contadorMarked = 0;
                Hashtable newPairTable = new Hashtable();
                foreach (DictionaryEntry de in pairTable)
                {
                    if ((String)de.Value == "") // estos hay que revisarlos!
                    {
                        String estadoP = (breakKey((String)de.Key))[0];
                        String estadoQ = (breakKey((String)de.Key))[1];
                        foreach (String alfa in alfabeto)
                        {
                            String marked = (String)pairTable[(String)automataAfnminimiza[estadoP + ":" + alfa] + ":" + (String)automataAfnminimiza[estadoQ + ":" + alfa]];
                            if (!String.IsNullOrEmpty(marked))
                            {
                                int markedIteracion = int.Parse((breakKey(marked))[1]);
                                if (markedIteracion == (iteraciones - 1))
                                {
                                    newPairTable.Add((String)de.Key, "X:" + iteraciones);
                                    contadorMarked++;
                                    break;
                                }
                            }
                            marked = (String)pairTable[(String)automataAfnminimiza[estadoQ + ":" + alfa] + ":" + (String)automataAfnminimiza[estadoP + ":" + alfa]];
                            if (!String.IsNullOrEmpty(marked))
                            {
                                int markedIteracion = int.Parse((breakKey(marked))[1]);
                                if (markedIteracion == (iteraciones - 1))
                                {
                                    newPairTable.Add((String)de.Key, "X:" + iteraciones);
                                    contadorMarked++;
                                    break;
                                }
                            }

                        }
                        if (!(newPairTable.ContainsKey((String)de.Key)))
                            newPairTable.Add((String)de.Key, "");
                    }
                    else
                    {
                        newPairTable.Add((String)de.Key, (String)de.Value);
                    }
                }
                pairTable = (Hashtable)newPairTable.Clone();
                afnetapasMinimizacionBU.Add((Hashtable)newPairTable.Clone());
                afnetapasMinimizacionExplicacionBU.Add("Pair Table: iteracion " + iteraciones);

                if (contadorMarked > 0)
                    iteraciones++;
            }

            ArrayList pairTableKeys = new ArrayList();
            foreach (DictionaryEntry de in pairTable)
            {
                if (((breakKey((String)de.Key))[0] != "sBasura") && ((breakKey((String)de.Key))[1] != "sBasura"))
                    pairTableKeys.Add((String)de.Key);
            }
            estadosAfn.Remove(estadoBasura.label);

            ArrayList newStates = new ArrayList();
            for (int i = 0; i < pairTableKeys.Count; i++)
            {
                if (((String)pairTable[pairTableKeys[i]]) == "")
                {
                    String estadoPi = breakKey((String)pairTableKeys[i])[0];
                    String estadoQi = breakKey((String)pairTableKeys[i])[1];
                    ArrayList newState = new ArrayList();
                    newState.Add(estadoPi);
                    newState.Add(estadoQi);
                    for (int j = 0; j < pairTableKeys.Count; j++)
                    {
                        if (((String)pairTable[pairTableKeys[j]]) == "")
                        {
                            String estadoPj = breakKey((String)pairTableKeys[j])[0];
                            String estadoQj = breakKey((String)pairTableKeys[j])[1];
                            if ((estadoPi == estadoPj) || (estadoQi == estadoPj) || (estadoPi == estadoQj) || (estadoQi == estadoQj))
                            {
                                if (!newState.Contains(estadoPj))
                                    newState.Add(estadoPj);
                                if (!newState.Contains(estadoQj))
                                    newState.Add(estadoQj);
                            }
                        }
                    }

                    Boolean isNew = true;
                    foreach (String de in newState)
                    {
                        foreach (ArrayList de2 in newStates)
                        {
                            if (de2.Contains(de))  // esta contenido en un macroestado
                            {
                                isNew = false;
                                break;
                            }
                        }
                    }
                    if (isNew)
                        newStates.Add(newState);
                }
            }

            Hashtable nuevosEstados = new Hashtable();
            for (int i = 0; i < newStates.Count; i++)
            {
                Hashtable nuevoEstado = new Hashtable();
                foreach (String state in (ArrayList)newStates[i])
                    nuevoEstado.Add(state, (State)estadosAfn[state]);
                State newState = new State(nuevoEstado);
                if (!nuevosEstados.ContainsKey(newState.label))
                    nuevosEstados.Add(newState.label, newState);
            }

            foreach (DictionaryEntry de in estadosAfn)
            {
                Boolean isNew = true;
                foreach (DictionaryEntry de2 in nuevosEstados)
                {
                    if (((State)de2.Value).contains((String)de.Key))  // esta contenido en un macroestado
                    {
                        isNew = false;
                        break;
                    }
                }
                if (isNew)
                    nuevosEstados.Add((String)de.Key, (State)de.Value);
            }
            estadosAfn = (Hashtable)nuevosEstados.Clone();


            Hashtable newAutomata = new Hashtable();
            Hashtable newLines = new Hashtable();
            Hashtable linesAdded = new Hashtable();
            foreach (DictionaryEntry de in estadosAfn)
            {
                State si = (State)de.Value;
                foreach (DictionaryEntry de2 in estadosAfn)
                {
                    foreach (String alfa in alfabeto)
                    {
                        State sj = (State)de2.Value;
                        if (si.esConjuntoDeEstados)
                        {
                            for (int k = 0; k < si.states.Length; k++)
                                if (sj.contains((String)automataAfnminimiza[si.get(k).label + ":" + alfa]))
                                {
                                    try
                                    {
                                        newAutomata.Add(si.label + ":" + alfa, sj.label);
                                        if ((lineasAfnminimiza.ContainsKey(si.label + ":" + alfa)) && (((Line)lineasAfnminimiza[si.label + ":" + alfa]).dest.label == sj.label))
                                        {
                                            newLines.Add(si.label + ":" + alfa, (Line)lineasAfnminimiza[si.label + ":" + alfa]);
                                        }
                                        else
                                        {
                                            int imx;
                                            int imy;
                                            int dy = sj.y - si.y;
                                            int dx = sj.x - si.x;
                                            imy = si.y + (dy / 2);
                                            imx = si.x + (dx / 2);
                                            if (!linesAdded.ContainsKey(si.label))
                                            {
                                                linesAdded.Add(si.label, 1);
                                            }
                                            else
                                            {
                                                int toAdd = (int)linesAdded[si.label];
                                                imy -= toAdd * 35;
                                                linesAdded.Remove(si.label);
                                                linesAdded.Add(si.label, (++toAdd));
                                            }
                                            if (!linesAdded.ContainsKey(sj.label))
                                                linesAdded.Add(sj.label, 1);
                                            else
                                            {
                                                int toAdd = (int)linesAdded[sj.label] + 1;
                                                linesAdded.Remove(sj.label);
                                                linesAdded.Add(sj.label, toAdd);
                                            }

                                            if (si.label == sj.label)
                                            {
                                                imx = si.x + 50;
                                                imy = si.y - 20;
                                                if (!linesAdded.ContainsKey(si.label + si.label))
                                                    linesAdded.Add(si.label + si.label, 1);
                                                else
                                                {
                                                    int toAdd = (int)linesAdded[si.label + si.label];
                                                    imy -= toAdd;
                                                    linesAdded.Remove(si.label + si.label);
                                                    linesAdded.Add(si.label + si.label, (++toAdd));
                                                }
                                            }

                                            Line l = new Line(si, sj, imx, imy);
                                            l.label = alfa;
                                            newLines.Add(si.label + ":" + alfa, l);
                                        }
                                        break;
                                    }
                                    catch (Exception) { }
                                }
                        }
                        else
                        {
                            if (sj.contains((String)automataAfnminimiza[si.label + ":" + alfa]))
                            {
                                try
                                {
                                    newAutomata.Add(si.label + ":" + alfa, sj.label);
                                    if ((lineasAfnminimiza.ContainsKey(si.label + ":" + alfa)) && (((Line)lineasAfnminimiza[si.label + ":" + alfa]).dest.label == sj.label))
                                    {
                                        newLines.Add(si.label + ":" + alfa, (Line)lineasAfnminimiza[si.label + ":" + alfa]);
                                    }
                                    else
                                    {
                                        int imx;
                                        int imy;
                                        int dy = sj.y - si.y;
                                        int dx = sj.x - si.x;
                                        imy = si.y + (dy / 2);
                                        imx = si.x + (dx / 2);
                                        if (!linesAdded.ContainsKey(si.label))
                                        {
                                            linesAdded.Add(si.label, 1);
                                        }
                                        else
                                        {
                                            int toAdd = (int)linesAdded[si.label];
                                            imy -= toAdd * 20;
                                            linesAdded.Remove(si.label);
                                            linesAdded.Add(si.label, (++toAdd));
                                        }
                                        if (si.label == sj.label)
                                        {
                                            imx = si.x + 50;
                                            imy = si.y - 20;
                                            if (!linesAdded.ContainsKey(si.label + si.label))
                                                linesAdded.Add(si.label + si.label, 1);
                                            else
                                            {
                                                int toAdd = (int)linesAdded[si.label + si.label];
                                                imy -= toAdd;
                                                linesAdded.Remove(si.label + si.label);
                                                linesAdded.Add(si.label + si.label, (++toAdd));
                                            }

                                        }
                                        Line l = new Line(si, sj, imx, imy);
                                        l.label = alfa;
                                        newLines.Add(si.label + ":" + alfa, l);
                                    }
                                }
                                catch (Exception) { }
                            }
                        }
                    }
                }
            }
            automataAfn = afdToAfn(newAutomata);
            lineasAfn = afdlineasToAfnlineas(newLines);
            Hashtable etapafinal = new Hashtable();
            etapafinal.Add("estados", cloneState(estadosAfn));
            etapafinal.Add("lineas", (Hashtable)lineasAfn.Clone());
            etapafinal.Add("automata", (Hashtable)automataAfn.Clone());
            afnetapasMinimizacionTD.Add(etapafinal);
            afnetapasMinimizacionExplicacionTD.Add("Etapa Final: Asi esta minimizado el Automatum");
            BottomUpAlgorithm bua = new BottomUpAlgorithm(afnetapasMinimizacionBU, afnetapasMinimizacionExplicacionBU);
            bua.Show();
            afdDraw.Refresh();
        }

        public void afntopDown()
        {
            oldestadosminimiza = (Hashtable)estadosAfn.Clone();
            oldlineasminimiza = (Hashtable)lineasAfn.Clone();
            oldautomataminimiza = (Hashtable)automataAfn.Clone();
            Hashtable etapa0 = new Hashtable();
            etapa0.Add("estados", oldestadosminimiza);
            etapa0.Add("lineas", lineasAfn);
            etapa0.Add("automata", oldautomataminimiza);
            afnetapasMinimizacionTD.Add(etapa0);
            afnetapasMinimizacionExplicacionTD.Add("Etapa Inicial");

            afntopleft.Visible = afnleft.Visible = afnclose.Visible = afnright.Visible = afntopright.Visible = afnlabel2.Visible = true;
            
            afnminimizaclicked = afnminimizaBUclicked = true;
            saveToolStripMenuItem.Enabled = true;

            Hashtable automataAfnminimiza = afnToAfd(automataAfn);
            Hashtable lineasAfnminimiza = afnlineasToAfdlineas(lineasAfn);

            /********************************************************************************************/
            Boolean isChanged = true; // quitar estados inservibles (unreachable)
            while (isChanged)
            {
                isChanged = false;
                Boolean inservible;
                ArrayList estadosInservibles = new ArrayList();

                foreach (DictionaryEntry de in estadosAfn)
                {
                    inservible = true;
                    foreach (DictionaryEntry de2 in automataAfnminimiza)
                    {
                        if (((String)de.Key == (String)de2.Value) && ((breakKey((String)de2.Key))[0] != (String)de.Key))
                        {
                            inservible = false;
                            break;
                        }
                    }
                    if ((inservible) && !((State)de.Value).isInitial)
                    {
                        estadosInservibles.Add((String)de.Key);
                        isChanged = true;
                    }
                }
                ArrayList toRemove = new ArrayList();
                for (int i = 0; i < estadosInservibles.Count; i++)
                {
                    String key = (String)estadosInservibles[i];
                    foreach (DictionaryEntry de in lineasAfnminimiza)
                    {
                        String[] toCheck = breakKey((String)de.Key);
                        if (toCheck[0] == key)
                            toRemove.Add((String)de.Key);
                        if (((Line)de.Value).dest.label == key)
                            toRemove.Add((String)de.Key);
                    }
                    for (int j = 0; j < toRemove.Count; j++)
                    {
                        lineasAfnminimiza.Remove(toRemove[j]);
                        automataAfnminimiza.Remove(toRemove[j]);
                    }
                    estadosAfn.Remove(key);
                    Hashtable etapaInservible = new Hashtable();
                    etapaInservible.Add("estados", (Hashtable)estadosAfn.Clone());
                    etapaInservible.Add("lineas", (Hashtable)lineasAfnminimiza.Clone());
                    etapaInservible.Add("automata", (Hashtable)automataAfnminimiza.Clone());
                    afnetapasMinimizacionTD.Add(etapaInservible);
                    afnetapasMinimizacionExplicacionTD.Add("Eliminacion estados Inservibles: Se elimino estado " + key);
                }
            }

            ArrayList alfabeto = new ArrayList(); // sacamos alfabeto
            foreach (DictionaryEntry de in automataAfnminimiza)
            {
                String[] keys = breakKey((String)de.Key);
                if (!alfabeto.Contains(keys[1]))
                    alfabeto.Add(keys[1]);
            }

            foreach (DictionaryEntry state in estadosAfn) // llenamos bien la matriz automata
                foreach (String alfa in alfabeto)
                    if (!automataAfnminimiza.Contains((String)state.Key + ":" + alfa))
                        automataAfnminimiza.Add((String)state.Key + ":" + alfa, "");
            
            String[] keysOrdenados = ordenarAfn();
            Hashtable finales = new Hashtable();
            Hashtable nofinales = new Hashtable();

            if (finales.Count == 0)
            {
                MessageBox.Show("No ha asignado estado(s) Finales al automatum!");
                afnclose.PerformClick();
                afnReset.PerformClick();
                return;
            }
            if (nofinales.Count == 0)
            {
                MessageBox.Show("No ha asignado estado(s) No Finales al automatum!");
                afnclose.PerformClick();
                afnReset.PerformClick();
                return;
            }

            for (int i = 0; i < keysOrdenados.Length; i++)
            {
                State s = (State)estadosAfn[keysOrdenados[i]];
                if (s.isFinal)
                    finales.Add(keysOrdenados[i], s);
                else
                    nofinales.Add(keysOrdenados[i], s);
            }

            State estadosFinales = new State(finales);
            State estadosNoFinales = new State(nofinales);
            ArrayList keysEstados = new ArrayList();

            keysEstados.Add(estadosNoFinales.label);
            keysEstados.Add(estadosFinales.label);
            estadosAfn.Clear();
            estadosAfn.Add(estadosFinales.label, estadosFinales);
            estadosAfn.Add(estadosNoFinales.label, estadosNoFinales);


// aqui esta error!
            int iteracion = 1;
            Hashtable etapa1 = new Hashtable();
            etapa1.Add("estados", (Hashtable)estadosAfn.Clone());
            etapa1.Add("lineas", new Hashtable());
            etapa1.Add("automata", new Hashtable());
            afnetapasMinimizacionTD.Add(etapa1);
            afnetapasMinimizacionExplicacionTD.Add("Etapa 1: Separacion Estados finales y no finales");

            isChanged = true;
            while (isChanged) // ciclo general
            {
                isChanged = false;
                ArrayList listToRemove = new ArrayList();
                for (int i = 0; i < keysEstados.Count; i++)
                {
                    Hashtable toRemove = new Hashtable();
                    String statesRemoved = "";
                    State thisState = (State)estadosAfn[keysEstados[i]];
                    Hashtable destinos = new Hashtable();
                    foreach (String alfa in alfabeto)
                    {
                        String dest = (String)automataAfnminimiza[thisState.get(0).label + ":" + alfa];
                        String toAddInDestinos = getDestinoStateLabel(estadosAfn, dest);
                        destinos.Add(alfa, toAddInDestinos);
                    }
                    for (int j = 1; j < thisState.states.Length; j++)
                    {
                        State sj = (State)thisState.get(j);
                        foreach (String alfa in alfabeto)
                        {
                            String dest = (String)automataAfnminimiza[sj.label + ":" + alfa];
                            String toAddInDestinos = getDestinoStateLabel(estadosAfn, dest);
                            if (toAddInDestinos != ((String)destinos[alfa]))
                            {
                                isChanged = true;
                                toRemove.Add(sj.label, sj);
                                statesRemoved += " " + sj.label;
                                break;
                            }
                        }
                    }
                    if (toRemove.Count > 0)
                    {
                        estadosAfn.Remove(thisState.label);
                        thisState.remove(toRemove);
                        keysEstados[i] = thisState.label;
                        estadosAfn.Add(thisState.label, thisState);
                        State newState = new State(toRemove);
                        estadosAfn.Add(newState.label, newState);
                        listToRemove.Add(toRemove);
                        Hashtable etapai = new Hashtable();
                        etapai.Add("estados", cloneState(estadosAfn));
                        etapai.Add("lineas", new Hashtable());
                        etapai.Add("automata", new Hashtable());
                        afnetapasMinimizacionTD.Add(etapai);
                        afnetapasMinimizacionExplicacionTD.Add("Etapa " + (++iteracion) + ": Estados separados: " + statesRemoved);
                    }
                }
                for (int i = 0; i < listToRemove.Count; i++)
                {
                    State newState = new State((Hashtable)listToRemove[i]);
                    keysEstados.Add(newState.label);
                }
            }

            Hashtable newAutomata = new Hashtable();
            Hashtable newLines = new Hashtable();
            Hashtable linesAdded = new Hashtable();
            for (int i = 0; i < keysEstados.Count; i++)
            {
                State si = (State)estadosAfn[keysEstados[i]];
                for (int j = 0; j < keysEstados.Count; j++)
                {
                    foreach (String alfa in alfabeto)
                    {
                        State sj = (State)estadosAfn[keysEstados[j]];
                        //    if (si.esConjuntoDeEstados)
                        //{
                        for (int k = 0; k < si.states.Length; k++)
                            if (sj.contains((String)automataAfnminimiza[si.get(k).label + ":" + alfa]))
                            {
                                newAutomata.Add(si.label + ":" + alfa, sj.label);
                                if ((lineasAfnminimiza.ContainsKey(si.label + ":" + alfa)) && (((Line)lineasAfnminimiza[si.label + ":" + alfa]).dest.label == sj.label))
                                {
                                    newLines.Add(si.label + ":" + alfa, (Line)lineasAfnminimiza[si.label + ":" + alfa]);
                                }
                                else
                                {
                                    int imx;
                                    int imy;
                                    int dy = sj.y - si.y;
                                    int dx = sj.x - si.x;
                                    imy = si.y + (dy / 2);
                                    imx = si.x + (dx / 2);
                                    if (!linesAdded.ContainsKey(si.label))
                                    {
                                        linesAdded.Add(si.label, 1);
                                    }
                                    else
                                    {
                                        int toAdd = (int)linesAdded[si.label];
                                        imy -= toAdd * 35;
                                        linesAdded.Remove(si.label);
                                        linesAdded.Add(si.label, (++toAdd));
                                    }
                                    if (!linesAdded.ContainsKey(sj.label))
                                        linesAdded.Add(sj.label, 1);
                                    else
                                    {
                                        int toAdd = (int)linesAdded[sj.label] + 1;
                                        linesAdded.Remove(sj.label);
                                        linesAdded.Add(sj.label, toAdd);
                                    }

                                    if (si.label == sj.label)
                                    {
                                        imx = si.x + 50;
                                        imy = si.y - 20;
                                        if (!linesAdded.ContainsKey(si.label + si.label))
                                            linesAdded.Add(si.label + si.label, 1);
                                        else
                                        {
                                            int toAdd = (int)linesAdded[si.label + si.label];
                                            imy -= toAdd;
                                            linesAdded.Remove(si.label + si.label);
                                            linesAdded.Add(si.label + si.label, (++toAdd));
                                        }
                                    }

                                    Line l = new Line(si, sj, imx, imy);
                                    l.label = alfa;
                                    newLines.Add(si.label + ":" + alfa, l);
                                }
                                break;
                            }
                    }
                }
            }
            automataAfn = newAutomata;
            lineasAfn = newLines;
            Hashtable etapafinal = new Hashtable();
            etapafinal.Add("estados", cloneState(estadosAfn));
            etapafinal.Add("lineas", afdlineasToAfnlineas(lineasAfn));
            etapafinal.Add("automata", afdToAfn(automataAfn));
            afnetapasMinimizacionTD.Add(etapafinal);
            afnetapasMinimizacionExplicacionTD.Add("Etapa Final: Asi esta minimizado el Automatum");
            afdDraw.Refresh();
        }

        private void afnclose_Click(object sender, EventArgs e)
        {
            afntopleft.Visible = afnleft.Visible = afnclose.Visible = afnright.Visible = afntopright.Visible = afnlabel2.Visible = false;
            afnminimizaclicked = afnminimizaBUclicked = afnminimizaTDclicked = false;
            afnEstados.Enabled = afnLineas.Enabled = afnBorrar.Enabled = afnLimpiar.Enabled = afnReset.Enabled = afnminimizar.Enabled = button6.Enabled = true;
            afnetapasCounterTD = 0;
            afnDraw.Refresh();
        }

        private void afntopleft_Click(object sender, EventArgs e)
        {
            afnetapasCounterTD = 0;
            afnDraw.Refresh();
        }

        private void afnleft_Click(object sender, EventArgs e)
        {
            afnetapasCounterTD--;
            afnDraw.Refresh();
        }

        private void afnright_Click(object sender, EventArgs e)
        {
            afnetapasCounterTD++;
            afnDraw.Refresh();
        }

        private void afntopright_Click(object sender, EventArgs e)
        {
            afnetapasCounterTD = afnetapasMinimizacionTD.Count - 1;
            afnDraw.Refresh();
        }

    }
}