function solve() {
  const tableBodyElement = document.querySelector(".table tbody");
  const [firstTextArea, secondTextArea] = Array.from(
    document.querySelectorAll("#exercise textarea")
  );
  const [generateButon, byButton] = Array.from(
    document.querySelectorAll("#exercise button")
  );

  generateButon.addEventListener("click", generatNew);
  byButton.addEventListener("click", ordered);

  function ordered(element) {
    const productsArrayElement = Array.from(
      tableBodyElement.querySelectorAll("tr")
    ).map((row) => {
      return Array.from(row.querySelectorAll("td"));
    });

    console.log(productsArrayElement);
    const byCar = productsArrayElement.reduce(
      (acc, product) => {
        const [img, name, price, facturi, isCheckt] = product;

        if (isCheckt.querySelector("input[type=checkbox]").checked) {
          acc["name"].push(name.textContent);
          acc["price"] += Number(price.textContent);
          acc["factor"] += Number(facturi.textContent);
        }

        return acc;
      },
      { name: [], price: 0, factor: 0 }
    );

    secondTextArea.textContent += `Bought furniture: ${byCar.name.join(
      ", "
    )}\n`;
    secondTextArea.textContent += `Total price: ${byCar.price.toFixed(2)}\n`;
    secondTextArea.textContent += `Average decoration factor: ${
      Number(byCar.factor) / byCar.name.length
    }`;
  }

  function generatNew(element) {
    const inputDate = JSON.parse(firstTextArea.value);

    for (const obj of inputDate) {
      const tableRowElement = document.createElement("tr");
      tableBodyElement.appendChild(tableRowElement);

      const imgTdElement = document.createElement("td");
      const imgElement = document.createElement("img");
      imgElement.src = obj.img;
      imgTdElement.appendChild(imgElement);
      tableRowElement.appendChild(imgTdElement);

      const titleTdElement = document.createElement("td");
      const pTitleElement = document.createElement("p");
      pTitleElement.textContent = obj.name;
      titleTdElement.appendChild(pTitleElement);
      tableRowElement.appendChild(titleTdElement);

      const priceTdElement = document.createElement("td");
      const pricePElement = document.createElement("p");
      pricePElement.textContent = obj.price;
      priceTdElement.appendChild(pricePElement);
      tableRowElement.appendChild(priceTdElement);

      const factoryTdElement = document.createElement("td");
      const factoryPElement = document.createElement("p");
      factoryPElement.textContent = obj.decFactor;
      factoryTdElement.appendChild(factoryPElement);
      tableRowElement.appendChild(factoryTdElement);

      const checkBoxTdElement = document.createElement("td");
      const checkBoxInputElement = document.createElement("input");
      checkBoxInputElement.type = "checkbox";
      checkBoxTdElement.appendChild(checkBoxInputElement);
      tableRowElement.appendChild(checkBoxTdElement);
    }
  }
}

// function solve() {
//   // Получаване на референции към нужните елементи от DOM дървото
//   const tableBodyElement = document.querySelector(".table tbody");
//   const [firstTextArea, secondTextArea] = Array.from(document.querySelectorAll("#exercise textarea"));
//   const [generateButton, buyButton] = Array.from(document.querySelectorAll("#exercise button"));

//   // Добавяне на събития към бутоните
//   generateButton.addEventListener("click", generateNew);
//   buyButton.addEventListener("click", buyFurniture);

//   // Функция за покупка на мебели
//   function buyFurniture() {
//     // Създаване на масив от всички редове в таблицата
//     const productsArray = Array.from(tableBodyElement.querySelectorAll("tr")).map(row => Array.from(row.querySelectorAll("td")));

//     // Редуциране на масива от редове до обща стойност на купените мебели
//     const boughtFurniture = productsArray.reduce((acc, product) => {
//       const [img, name, price, factor, checkbox] = product;

//       // Проверка дали чекбоксът е отметнат
//       if (checkbox.querySelector("input[type=checkbox]").checked) {
//         acc["name"].push(name.textContent);
//         acc["price"] += Number(price.textContent);
//         acc["factor"] += Number(factor.textContent);
//       }

//       return acc;
//     }, { name: [], price: 0, factor: 0 });

//     // Извеждане на информацията за купените мебели във второто текстово поле
//     secondTextArea.textContent += `Bought furniture: ${boughtFurniture.name.join(", ")}\n`;
//     secondTextArea.textContent += `Total price: ${boughtFurniture.price.toFixed(2)}\n`;
//     secondTextArea.textContent += `Average decoration factor: ${Number(boughtFurniture.factor) / boughtFurniture.name.length}`;
//   }

//   // Функция за генериране на нови редове в таблицата
//   function generateNew() {
//     const inputData = JSON.parse(firstTextArea.value);

//     // Зареждане на данните от входа и създаване на редове за всяка мебел
//     for (const obj of inputData) {
//       const tableRowElement = document.createElement("tr");
//       tableBodyElement.appendChild(tableRowElement);

//       // Създаване на колони за картинка, име, цена, фактор и чекбокс за всяка мебел
//       const imgTdElement = createTableCell("img", obj.img);
//       const titleTdElement = createTableCell("p", obj.name);
//       const priceTdElement = createTableCell("p", obj.price);
//       const factorTdElement = createTableCell("p", obj.decFactor);
//       const checkboxTdElement = createTableCell("input", "", "checkbox");

//       // Добавяне на създадените колони към реда в таблицата
//       tableRowElement.append(imgTdElement, titleTdElement, priceTdElement, factorTdElement, checkboxTdElement);
//     }
//   }

//   // Помощна функция за създаване на клетка в таблицата с подаден тип, съдържание и опционален тип на елемента
//   function createTableCell(elementType, content = "", inputType = "") {
//     const cellElement = document.createElement("td");

//     if (elementType === "img") {
//       const imgElement = document.createElement("img");
//       imgElement.src = content;
//       cellElement.appendChild(imgElement);
//     } else if (elementType === "input") {
//       const inputElement = document.createElement("input");
//       inputElement.type = inputType;
//       cellElement.appendChild(inputElement);
//     } else {
//       const textElement = document.createElement(elementType);
//       textElement.textContent = content;
//       cellElement.appendChild(textElement);
//     }

//     return cellElement;
//   }
// }
