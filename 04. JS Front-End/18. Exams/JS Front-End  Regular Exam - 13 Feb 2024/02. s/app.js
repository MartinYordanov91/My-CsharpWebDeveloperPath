window.addEventListener("load", solve);

function solve() {
  const buttonAddElement = document.getElementById("add-btn");

  const inputNameElement = document.getElementById("name");
  const inputPhoneElement = document.getElementById("phone");
  const inputCategoryElement = document.getElementById("category");

  const ulCheckListElement = document.getElementById("check-list");
  const ulContactListElement = document.getElementById("contact-list");

  buttonAddElement.addEventListener("click", chekCreateClean);

  function chekCreateClean() {
    const contactObj = inputObject();

    if (!contactObj) {
      return;
    }
    createContact(contactObj);
    cleanInputs();
  }

  function createContact(data) {
    const buttonDeleteElement = document.createElement("button");
    buttonDeleteElement.classList.add("del-btn");

    const buttonSaveElement = document.createElement("button");
    buttonSaveElement.classList.add("save-btn");

    const buttonEditElement = document.createElement("button");
    buttonEditElement.classList.add("edit-btn");

    const divButtonConteinerElement = document.createElement("div");
    divButtonConteinerElement.classList.add("buttons");

    divButtonConteinerElement.appendChild(buttonEditElement);
    divButtonConteinerElement.appendChild(buttonSaveElement);

    const pNameElement = document.createElement("p");
    pNameElement.textContent = `name:` + data.name;

    const pPhoneElement = document.createElement("p");
    pPhoneElement.textContent = `phone:` + data.phone;

    const pCategoryElement = document.createElement("p");
    pCategoryElement.textContent = `category:` + data.category;

    const articleContenElement = document.createElement("article");

    articleContenElement.appendChild(pNameElement);
    articleContenElement.appendChild(pPhoneElement);
    articleContenElement.appendChild(pCategoryElement);

    const liContactElement = document.createElement("li");

    liContactElement.appendChild(articleContenElement);
    liContactElement.appendChild(divButtonConteinerElement);
    ulCheckListElement.appendChild(liContactElement);

    buttonEditElement.addEventListener("click", () => {
      populateData(data);
      liContactElement.remove();
    });

    buttonSaveElement.addEventListener("click", () => {
      liContactElement.remove();
      divButtonConteinerElement.remove();
      ulContactListElement.appendChild(liContactElement);
      liContactElement.appendChild(buttonDeleteElement);
    });

    buttonDeleteElement.addEventListener("click", () => {
      liContactElement.remove();
    });
  }

  function cleanInputs() {
    inputNameElement.value = "";
    inputPhoneElement.value = "";
    inputCategoryElement.value = "";
  }

  function populateData(data) {
    inputNameElement.value = data.name;
    inputPhoneElement.value = data.phone;
    inputCategoryElement.value = data.category;
  }

  function inputObject() {
    const name = inputNameElement.value;
    const phone = inputPhoneElement.value;
    const category = inputCategoryElement.value;

    if (!name || !phone || !category) {
      return;
    }

    return { name, phone, category };
  }
}
