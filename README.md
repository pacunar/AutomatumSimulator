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

Examples:
---------

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

For now, I'll use my free time to improve it (see the big TODO list).

Wishful thinking: someone with more expertise in C# can help me improve the code. 


TODO: 
=====


