const baseUrl = `http://localhost:3030/jsonstore/tasks/`;

const inputNameElement = document.getElementById("course-name");
const inputTypeElement = document.getElementById("course-type");
const inputDescriptionElement = document.getElementById("description");
const inputTheacherElement = document.getElementById("teacher-name");

const buttonAddElement = document.getElementById("add-course");
const buttonEditElement = document.getElementById("edit-course");
const buttonLoadElement = document.getElementById("load-course");

const divListElement = document.getElementById("list");

buttonLoadElement.addEventListener("click", reloadAll);
buttonAddElement.addEventListener("click", (e) => newCourse(e));
buttonEditElement.addEventListener("click", (e) => editingCourse(e));

function editingCourse(e) {
  e.preventDefault();
  const { title, type, description, teacher } = inputObject();
  const _id = buttonEditElement.getAttribute("data-id");

  fetch(baseUrl + _id, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ title, type, description, teacher, _id }),
  }).then(() => {
    reloadAll();
  });

  clearInputs();
  buttonAddElement.disabled = false;
  buttonEditElement.disabled = true;
  buttonEditElement.removeAttribute("data-id");
}

function newCourse(e) {
  e.preventDefault();
  const courseObj = inputObject();

  if (!courseObj) {
    return;
  }

  fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(courseObj),
  }).then(() => {
    reloadAll();
  });

  clearInputs();
}

function reloadAll() {
  fetch(baseUrl)
    .then((res) => res.json())
    .then((courses) => {
      divListElement.innerHTML = "";

      Object.values(courses).forEach((corse) => {
        createAndLoadElement(corse);
      });
    });
}

function createAndLoadElement(element) {
  const buttonFinishElement = document.createElement("button");
  buttonFinishElement.classList.add("finish-btn");
  buttonFinishElement.textContent = "Finish Course";

  const buttonChangeElement = document.createElement("button");
  buttonChangeElement.classList.add("edit-btn");
  buttonChangeElement.textContent = "Edit Course";

  const h4DescriptionElement = document.createElement("h4");
  h4DescriptionElement.textContent = element.description;

  const h3TypeElement = document.createElement("h3");
  h3TypeElement.textContent = element.type;

  const h3TheacherElement = document.createElement("h3");
  h3TheacherElement.textContent = element.teacher;

  const h2TitleElement = document.createElement("h2");
  h2TitleElement.textContent = element.title;

  const divConteinerElement = document.createElement("div");
  divConteinerElement.classList.add("container");

  divConteinerElement.appendChild(h2TitleElement);
  divConteinerElement.appendChild(h3TheacherElement);
  divConteinerElement.appendChild(h3TypeElement);
  divConteinerElement.appendChild(h4DescriptionElement);
  divConteinerElement.appendChild(buttonChangeElement);
  divConteinerElement.appendChild(buttonFinishElement);
  divListElement.appendChild(divConteinerElement);

  buttonChangeElement.addEventListener("click", () => {
    divConteinerElement.remove();
    populateInputs(element);
    buttonAddElement.disabled = true;
    buttonEditElement.disabled = false;
  });

  buttonFinishElement.addEventListener("click", () => {
    fetch(baseUrl + element._id, {
      method: "DELETE",
    }).then(() => {
      reloadAll();
    });
  });
}

function clearInputs() {
  inputNameElement.value = "";
  inputTypeElement.value = "";
  inputDescriptionElement.value = "";
  inputTheacherElement.value = "";
}

function inputObject() {
  const title = inputNameElement.value;
  const type = inputTypeElement.value;
  const description = inputDescriptionElement.value;
  const teacher = inputTheacherElement.value;

  if (!title || !type || !description || !teacher) {
    return;
  }

  if (!(type === "Long" || type === "Medium" || type === "Short")) {
    return;
  }
  return { title, type, description, teacher };
}

function populateInputs(element) {
  inputNameElement.value = element.title;
  inputTypeElement.value = element.type;
  inputDescriptionElement.value = element.description;
  inputTheacherElement.value = element.teacher;
  buttonEditElement.setAttribute("data-id", element._id);
}
