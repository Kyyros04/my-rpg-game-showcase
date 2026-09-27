# Unity RPG Architecture & Design Patterns Showcase

This repository serves as a curated, ongoing catalog of software engineering design patterns implemented within a large-scale 2D RPG project (+30,000 lines of proprietary C# code). 

Instead of exposing the full proprietary codebase, this project isolates core monolithic systems into decoupled, clean, and highly reusable architecture modules. It demonstrates how traditional Gang of Four (GoF) and game-specific programming patterns solve real-world performance and scalability issues in Unity.

---

## Repository Structure & Patterns Catalog

### Input & View Decoupling (Command & Observer Patterns)
* **Directory:** `ManagerInput/`
* **Patterns Used:** Command Pattern, Observer Pattern, Null Object Pattern, Component-Based Singleton.
* **Problem Solved:** Prevents monolithic `if/else` conditioning inside the player class during state shifts (e.g., cutscenes, dialogue locks, or custom camera tracking routines).
* **Key Concept:** Isolates hardware polling input parameters from physical/graphical translation wrappers, allowing real-time polymorphic swapping of active execution scripts via a centralized gateway.

---

## Upcoming Architecture Showcases (In Progress)

...

---

## License
This project is licensed under the **MIT License** - see the `LICENSE` file for details.
