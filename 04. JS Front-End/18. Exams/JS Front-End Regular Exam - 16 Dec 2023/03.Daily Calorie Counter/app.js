const baseUrl = `http://localhost:3030/jsonstore/tasks`;

const inputFoodElement = document.getElementById("food");
const inputTimeElement = document.getElementById("time");
const inputCaloriesElement = document.getElementById("calories");
const buttonAddElement = document.getElementById("add-meal");
const buttonEditElement = document.getElementById("edit-meal");
const listMealElement = document.getElementById("list");
let curentMealId;

buttonAddElement.addEventListener("click", () => {
  const food = inputFoodElement.value;
  const time = inputTimeElement.value;
  const calories = inputCaloriesElement.value;

  if (!food || !time || !calories) {
    return;
  }
  fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ food: food, calories: calories, time: time }),
  }).then((res) => {
    reloadAll();
  });
  inputFoodElement.value = "";
  inputTimeElement.value = "";
  inputCaloriesElement.value = "";
});

buttonEditElement.addEventListener("click", () => {
  fetch(`${baseUrl}/${curentMealId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      food: inputFoodElement.value,
      calories: inputCaloriesElement.value,
      time: inputTimeElement.value,
      _id: curentMealId,
    }),
  })
    .then((res) => res.json())
    .then((update) => {
      inputFoodElement.value = "";
      inputTimeElement.value = "";
      inputCaloriesElement.value = "";
      buttonAddElement.disabled = false;
      buttonEditElement.disabled = true;
      curentMealId = "";
      reloadAll();
    });
});

const buttonLoadElement = document.getElementById("load-meals");
buttonLoadElement.addEventListener("click", () => {
  reloadAll();
});

function reloadAll() {
  fetch(baseUrl)
    .then((res) => res.json())
    .then((meals) => {
      listMealElement.innerHTML = "";

      Object.values(meals).forEach((meal) => {
        createAndLoadElement(meal);
      });
    });
}

function createAndLoadElement(meal) {
  const divMealElement = document.createElement("div");
  divMealElement.classList.add("meal");

  const h2Element = document.createElement("h2");
  h2Element.textContent = meal.food;

  const h3TimeElement = document.createElement("h3");
  h3TimeElement.textContent = meal.time;

  const h3CaloriesElement = document.createElement("h3");
  h3CaloriesElement.textContent = meal.calories;

  const divButtonsElement = document.createElement("div");
  divButtonsElement.classList.add("meal-buttons");

  const buttonChangeElement = document.createElement("button");
  buttonChangeElement.classList.add("change-meal");
  buttonChangeElement.textContent = "Change";

  buttonChangeElement.addEventListener("click", () => {
    inputFoodElement.value = meal.food;
    inputTimeElement.value = meal.time;
    inputCaloriesElement.value = meal.calories;
    curentMealId = meal._id;

    buttonAddElement.disabled = true;
    buttonEditElement.disabled = false;
    divMealElement.remove();
  });

  const buttonDeleteElement = document.createElement("button");
  buttonDeleteElement.classList.add("delete-meal");
  buttonDeleteElement.textContent = "Delete";

  buttonDeleteElement.addEventListener("click", () => {
    fetch(`${baseUrl}/${meal._id}`, {
      method: "DELETE",
    });
    divMealElement.remove();
  });

  listMealElement.appendChild(divMealElement);
  divMealElement.appendChild(h2Element);
  divMealElement.appendChild(h3TimeElement);
  divMealElement.appendChild(h3CaloriesElement);
  divMealElement.appendChild(divButtonsElement);
  divButtonsElement.appendChild(buttonChangeElement);
  divButtonsElement.appendChild(buttonDeleteElement);
}
