# 🛒 TRANS-HEALTH HRT SPECIALTY SHOP
**Student Developer:** Clint John P. Gelilang  
**Section:** BSIT 1-2  
**Affiliation:** Polytechnic University of the Philippines (PUP)

---

## 📋 PROJECT OVERVIEW
This application is a **Console-Based Shopping Cart System** developed using **C#**. It is specifically designed to simulate a point-of-sale system for an HRT (Hormone Replacement Therapy) specialty shop. The project demonstrates a strong grasp of Object-Oriented Programming (OOP) concepts, particularly in managing product entities and transaction logic.

---

## ⚙️ CORE SYSTEM SPECIFICATIONS

### 1. Object-Oriented Architecture
* **`Product` Class:** Encapsulates essential data fields including `Id`, `Name`, `Price`, and `RemainingStock`.
* **Custom Methods:** * `DisplayProduct()` - Renders a formatted view of the product details.
    * `HasEnoughStock()` - A logic gate to verify inventory before adding to the cart.
    * `DeductStock()` - Updates the inventory counts upon successful transaction.

### 2. Robust Validation System
* **Data Integrity:** Implements `int.TryParse()` for all user inputs (Product ID and Quantity) to prevent application crashes caused by non-numeric characters.
* **Selection Checks:** Validates if the user input falls within the valid range of IDs (1-8).
* **Inventory Guard:** Specifically handles cases where a product is "Out of Stock" or the requested quantity exceeds the current supply.

### 3. Shopping Cart & Checkout Logic
* **Smart Item Handling:** Instead of duplicating rows, the system detects if an item is already in the cart and updates the quantity and subtotal accordingly.
* **Pricing & Discounts:** Calculates a subtotal for each item. If the **Grand Total is ₱5,000 or more**, the system automatically applies a **10% Discount**.
* **Post-Transaction Inventory:** Displays the final remaining stock for all items, ensuring the store's inventory is up-to-date after the sale.

---

## 🤖 AI ASSISTANCE DISCLOSURE
This project utilized AI assistance (Gemini) for the following:
* **Code Optimization:** Refinement of the duplicate entry detection logic.
* **Error Handling:** Best practices for using `int.TryParse()` to ensure "zero-crash" performance.
* **Documentation:** Generation of this README file and project structure.

**Modifications Made:** I personally customized the product list to reflect an HRT Shop theme, adjusted the pricing, and tailored the console UI's formatting (using `String Padding`) to ensure it looks professional in the terminal.

---

## 📁 REPOSITORY CONTENTS
* `Program.cs` - The complete source code.
* `README.md` - Technical documentation (This file).
* `Flowchart.png` - Verbose flowchart of the system's logic.

---
*© 2026 Clint John P. Gelilang. Dedicated to providing healthcare solutions for the community.* ✨
