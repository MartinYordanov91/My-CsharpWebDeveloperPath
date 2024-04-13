const baseUrl = `http://localhost:3030/jsonstore/tasks/`;

const inputNameElement = document.getElementById("name");
const inputNumDaysElement = document.getElementById("num-days");
const inputFromDateElement = document.getElementById("from-date");
const buttonAddElement = document.getElementById("add-vacation");
const buttonEditElement = document.getElementById("edit-vacation");
const buttonLoadElement = document.getElementById("load-vacations");
const divListVacantionsElement = document.getElementById("list");

buttonLoadElement.addEventListener("click", reloadAll);
buttonAddElement.addEventListener("click", (e) => newVacantion(e));
buttonEditElement.addEventListener("click", (e) => editingVacantion(e));

function newVacantion(e) {
  e.preventDefault();
  const vacantion = inputObject();

  if (!vacantion) {
    return;
  }

  fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(vacantion),
  })
    .then((res) => res.json())
    .then(() => {
      reloadAll();
    });

  clearInputs();
}

function editingVacantion(e) {
  e.preventDefault();
  const { name, date, days } = inputObject();
  const _id = buttonEditElement.getAttribute("data-id");
  fetch(baseUrl + _id, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ name, date, days, _id }),
  }).then(() => {
    reloadAll();
  });
  clearInputs();
  buttonEditElement.removeAttribute("data-id");
  buttonEditElement.disabled = true;
  buttonAddElement.disabled = false;
}

function createAndLoadElement(element) {
  const buttonDoneElement = document.createElement("button");
  buttonDoneElement.classList.add("done-btn");
  buttonDoneElement.textContent = "Done";

  const buttonChangeElement = document.createElement("button");
  buttonChangeElement.classList.add("change-btn");
  buttonChangeElement.textContent = "Change";

  const h3DaysElement = document.createElement("h3");
  h3DaysElement.textContent = element.days;

  const h3DateFromElement = document.createElement("h3");
  h3DateFromElement.textContent = element.date;

  const h2NameElement = document.createElement("h2");
  h2NameElement.textContent = element.name;

  const divContainerElement = document.createElement("div");
  divContainerElement.classList.add("container");

  divContainerElement.appendChild(h2NameElement);
  divContainerElement.appendChild(h3DateFromElement);
  divContainerElement.appendChild(h3DaysElement);
  divContainerElement.appendChild(buttonChangeElement);
  divContainerElement.appendChild(buttonDoneElement);
  divListVacantionsElement.appendChild(divContainerElement);

  buttonChangeElement.addEventListener("click", () => {
    divContainerElement.remove();
    populateDate(element);
    buttonAddElement.disabled = true;
    buttonEditElement.disabled = false;
  });

  buttonDoneElement.addEventListener("click", () => {
    fetch(baseUrl + element._id, {
      method: "DELETE",
    }).then(() => {
      reloadAll();
    });
  });
}

function reloadAll() {
  fetch(baseUrl)
    .then((res) => res.json())
    .then((vacantions) => {
      divListVacantionsElement.innerHTML = "";
      Object.values(vacantions).forEach((vacantion) => {
        createAndLoadElement(vacantion);
      });
    });
}

function inputObject() {
  const name = inputNameElement.value;
  const days = inputNumDaysElement.value;
  const date = inputFromDateElement.value;

  if (!name || !days || !date) {
    return;
  }
  return { name, days, date };
}

function clearInputs() {
  inputNameElement.value = "";
  inputNumDaysElement.value = "";
  inputFromDateElement.value = "";
}

function populateDate(date) {
  inputNameElement.value = date.name;
  inputNumDaysElement.value = date.days;
  inputFromDateElement.value = date.date;
  buttonEditElement.setAttribute("data-id", date._id);
}
