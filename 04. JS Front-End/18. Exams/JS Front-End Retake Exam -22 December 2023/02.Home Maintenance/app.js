window.addEventListener("load", solve);

function solve() {
  const inputPlaceElement = document.getElementById("place");
  const inputActionElement = document.getElementById("action");
  const inputPersonElement = document.getElementById("person");
  const listTasksElement = document.getElementById("task-list");
  const listDoneElement = document.getElementById("done-list");
  const buttonAdd = document.getElementById("add-btn");

  buttonAdd.addEventListener("click", () => {
    const place = inputPlaceElement.value;
    const action = inputActionElement.value;
    const person = inputPersonElement.value;

    if (!place || !action || !person) {
      return;
    }

    inputPlaceElement.value = "";
    inputActionElement.value = "";
    inputPersonElement.value = "";

    newTasksHtml(place, action, person);
  });

  function newTasksHtml(place, action, person) {
    const liElement = document.createElement("li");
    liElement.classList.add("clean-task");

    const articleElement = document.createElement("article");

    const pPlaceElement = document.createElement("p");
    pPlaceElement.textContent = `Place:${place}`;
    const pActionElement = document.createElement("p");
    pActionElement.textContent = `Action:${action}`;
    const pPersonElement = document.createElement("p");
    pPersonElement.textContent = `Person:${person}`;

    const divElement = document.createElement("div");
    divElement.classList.add("buttons");

    const buttonEdit = document.createElement("button");
    buttonEdit.classList.add("edit");
    buttonEdit.textContent = "Edit";

    const buttonDone = document.createElement("button");
    buttonDone.classList.add("done");
    buttonDone.textContent = "Done";

    const buttonDelite = document.createElement("button");
    buttonDelite.classList.add("delete");
    buttonDelite.textContent = "Delete";

    listTasksElement.appendChild(liElement);
    liElement.appendChild(articleElement);
    liElement.appendChild(divElement);
    articleElement.appendChild(pPlaceElement);
    articleElement.appendChild(pActionElement);
    articleElement.appendChild(pPersonElement);
    divElement.appendChild(buttonEdit);
    divElement.appendChild(buttonDone);

    buttonEdit.addEventListener("click", () => {
      inputPlaceElement.value = place;
      inputActionElement.value = action;
      inputPersonElement.value = person;
      listTasksElement.removeChild(liElement);
    });

    buttonDone.addEventListener("click", () => {
      liElement.removeChild(divElement);
      liElement.appendChild(buttonDelite);
      listTasksElement.removeChild(liElement);
      listDoneElement.appendChild(liElement);
    });

    buttonDelite.addEventListener("click", () => {
      listDoneElement.removeChild(liElement);
    });
  }
}
