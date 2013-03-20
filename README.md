AutomatumSimulator
==================

Visual application to create and simulate [Finite State Machine](http://en.wikipedia.org/wiki/Finite-state_machine): Deterministic and non-Deterministic state machines can be created and simulated using this visual tool

The application features are: 
* Define Deterministic Finite State Machine, or Deterministic Finite Automaton ([**DFA**](http://en.wikipedia.org/wiki/Deterministic_finite_automaton)), creating states and arcs in a visual way
* Observe a matrix representation of the **DFA** 
* Evaluate a set of characters as input of the state machine, presenting an animation of each transition until the set is accepted or rejected.
* Minimize the **DFA** using two algorithms: Top-Down or Bottom-up
* Define Non-deterministic Finite State Machine or Non-Deterministic Finite Automaton ([**NFA**](http://en.wikipedia.org/wiki/Nondeterministic_finite_automaton)), creating states and arcs visually. 
* Observe a matrix representation of the **NFA**
* Evaluate a set of characters as input of the state machine, presenting an animation of each transition until the set is accepted or rejected. Different from the **DFA**, the **NFA** animation asks the user for a choice between different transition options. 
* Transform and **NFA** into a **DFA** using a Closure algorithm, presenting all steps involved in the transformation
* The transformed **DFA** can also be minimized and evaluated using a set of characters as input.

### Examples:

A simple **DFA** example: 

![Image](resources/images/DFAExample1.png?raw=true)

An example of an animation in a simple **DFA** example: 

![Image](resources/images/AnimationExample.png?raw=true)


Created using **C#** using **Microsoft Visual Studio**.

A little history: 
-----------------
This was the app of my final dissertation for my bachelor's degree co-created with a friend and colleague, and we used this application for demonstrating the use of finite state machines (FSM). The application was created in 2005.

I recently found the source code, and after fixing some compatibility errors I have decided to open-source it, in case it's helpful for someone else. 

Doing a quick search at Github, I've found many similar solutions, but not many of them have visual tools for creating, minimizing and simulating the funcionalities of FSM. Because of this, I thought in releasing the old code and retaking the project. 

There are many issues and features that can be added, and existing features that can be improved (a *lot*!).

For now, I'll use my free time to improve it, besides it's probable that I'll use it in the near future so I'm the most interested in improving this.

Wishful thinking: someone with more expertise in C# can help me improve the code. 


TODO: 
-----

There's a **BIG** list of bugs, issues and improvements, I'll try to list them by priority: 
* Right now (I'm a little embarassed about this) there's no objects in the source code. The main class has almost all source code of the application, making it unreadable and very inefficient
* Translate texts (labels, messages, titles, etc.) from spanish to english -- use a translation library for supporting both languages?
* Improve drawing algorithm of automatically generated automata after minimize or transform.
* Add visual feedback to the creation of states and lines
* Allow actions on created elements: selection, drag&drop, deleting, double-click or right-click
* Allow selecting lines for editing its information
* Check bugs after transformation
