const baseUrl = `http://localhost:3030/jsonstore/tasks`;

const divListElements = document.getElementById("list");
const buttonAddElement = document.getElementById("add-weather");
const buttonEditElement = document.getElementById("edit-weather");
const buttonLoadElement = document.getElementById("load-history");
const inputLocationElement = document.getElementById("location");
const inputTemperatureElement = document.getElementById("temperature");
const inputDateElement = document.getElementById("date");

buttonEditElement.addEventListener("click", () => {
  let dateId = buttonEditElement.getAttribute("data-id");
  const { location, temperature, date } = inputObject();

  fetch(`${baseUrl}/${dateId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ location, temperature, date, _id: dateId }),
  })
    .then((res) => res.json())
    .then(() => {
      reLoadAll();
      buttonEditElement.removeAttribute("data-id");
      buttonEditElement.disabled = true;
      buttonAddElement.disabled = false;
    });

  cleanInput();
});

buttonLoadElement.addEventListener("click", () => {
  reLoadAll();
});

buttonAddElement.addEventListener("click", () => {
  const newWeather = inputObject();
  fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newWeather),
  })
    .then((res) => res.json())
    .then(() => {
      reLoadAll();
    });
  cleanInput();
});

function createLoadElement(element) {
  const buttonDeleteElement = document.createElement("button");
  buttonDeleteElement.classList.add("delete-btn");
  buttonDeleteElement.textContent = "Delete";

  const buttonChangeElement = document.createElement("button");
  buttonChangeElement.classList.add("change-btn");
  buttonChangeElement.textContent = "Change";

  const divButtonConternerElement = document.createElement("div");
  divButtonConternerElement.classList.add("buttons-container");
  divButtonConternerElement.appendChild(buttonChangeElement);
  divButtonConternerElement.appendChild(buttonDeleteElement);

  const h3DegriceElement = document.createElement("h3");
  h3DegriceElement.id = "celsius";
  h3DegriceElement.textContent = element.temperature;

  const h3DateElement = document.createElement("h3");
  h3DateElement.textContent = element.date;

  const h2LocationElement = document.createElement("h2");
  h2LocationElement.textContent = element.location;

  const divConteinerElement = document.createElement("div");
  divConteinerElement.classList.add("container");
  divConteinerElement.appendChild(h2LocationElement);
  divConteinerElement.appendChild(h3DateElement);
  divConteinerElement.appendChild(h3DegriceElement);
  divConteinerElement.appendChild(divButtonConternerElement);

  divListElements.appendChild(divConteinerElement);

  buttonChangeElement.addEventListener("click", () => {
    buttonEditElement.setAttribute("data-id", element._id);
    divConteinerElement.remove();
    populateFilds(element);
    buttonAddElement.disabled = true;
    buttonEditElement.disabled = false;
  });

  buttonDeleteElement.addEventListener("click", () => {
    fetch(`${baseUrl}/${element._id}`, {
      method: "DELETE",
    }).then(() => {
      reLoadAll();
    });
  });
}

function cleanInput() {
  inputLocationElement.value = "";
  inputTemperatureElement.value = "";
  inputDateElement.value = "";
}

function reLoadAll() {
  fetch(baseUrl)
    .then((res) => res.json())
    .then((locations) => {
      divListElements.innerHTML = "";
      Object.values(locations).forEach((location) => {
        createLoadElement(location);
      });
    });
}

function inputObject() {
  const location = inputLocationElement.value;
  const temperature = inputTemperatureElement.value;
  const date = inputDateElement.value;

  if (!location || !temperature || !date) {
    return;
  }

  return { location, temperature, date };
}

function populateFilds(object) {
  inputLocationElement.value = object.location;
  inputTemperatureElement.value = object.temperature;
  inputDateElement.value = object.date;
}
