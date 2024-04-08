function attachEvents() {
  const baseUrl = `http://localhost:3030/jsonstore/collections/students`;

  const tableBodyElement = document.querySelector(`#results tbody`);
  const inputFirstNameElement = document.querySelector(
    "input[name =firstName]"
  );
  const inputLastNameElement = document.querySelector("input[name =lastName]");
  const inputFacultyNumberElement = document.querySelector(
    "input[name =facultyNumber]"
  );
  const inputGradeElement = document.querySelector("input[name =grade]");
  const buttonSubmitElement = document.getElementById("submit");

  buttonSubmitElement.addEventListener("click", postNewStudent);

  fetch(baseUrl)
    .then((res) => res.json())
    .then((students) => {
      const studentsArry = Object.values(students).map((student) => {
        loadAndCreateStudent(student);
      });
    });

  function postNewStudent() {
    const firstName = inputFirstNameElement.value;
    const lastName = inputLastNameElement.value;
    const facultyNumber = inputFacultyNumberElement.value;
    const grade = inputGradeElement.value;

    if (!firstName || !lastName || !facultyNumber || !grade) {
      return;
    }

    const student = {
      firstName,
      lastName,
      facultyNumber,
      grade,
    };

    fetch(baseUrl, {
      method: "POST",
      headers: {
        "content-Type": "application/json",
      },
      body: JSON.stringify(student),
    })
      .then((res) => res.json())
      .then((student) => loadAndCreateStudent(student));
  }

  function loadAndCreateStudent({
    firstName,
    lastName,
    facultyNumber,
    grade,
    _id,
  }) {
    const trElement = document.createElement("tr");
    trElement.id = _id;

    const tdFirstNameElement = document.createElement("td");
    tdFirstNameElement.textContent = firstName;

    const tdLastNameElement = document.createElement("td");
    tdLastNameElement.textContent = lastName;

    const tdFacultyNumberElement = document.createElement("td");
    tdFacultyNumberElement.textContent = facultyNumber;

    const tdGradeElement = document.createElement("td");
    tdGradeElement.textContent = grade;

    if (!firstName || !lastName || !facultyNumber || !grade) {
      return;
    }

    trElement.appendChild(tdFirstNameElement);
    trElement.appendChild(tdLastNameElement);
    trElement.appendChild(tdFacultyNumberElement);
    trElement.appendChild(tdGradeElement);
    tableBodyElement.appendChild(trElement);
  }
}

attachEvents();
