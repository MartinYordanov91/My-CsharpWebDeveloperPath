function attachEventsListeners() {
  const convertToMeeter = {
    km: (num) => num * 1000,
    m: (num) => num,
    cm: (num) => num * 0.01,
    mm: (num) => num * 0.001,
    mi: (num) => num * 1609.34,
    yrd: (num) => num * 0.9144,
    ft: (num) => num * 0.3048,
    in: (num) => num * 0.0254,
  };

  const convertFromMeeter = {
    km: (num) => num / 1000,
    m: (num) => num,
    cm: (num) => num / 0.01,
    mm: (num) => num / 0.001,
    mi: (num) => num / 1609.34,
    yrd: (num) => num / 0.9144,
    ft: (num) => num / 0.3048,
    in: (num) => num / 0.0254,
  };

  const selectedElementFrom = document.getElementById("inputUnits");
  const inputElementFrom = document.getElementById("inputDistance");
  const selectedElementTo = document.getElementById("outputUnits");
  const outtElementTo = document.getElementById("outputDistance");

  document.getElementById("convert").addEventListener("click", (e) => {
    const curentMeters = convertToMeeter[selectedElementFrom.value](
      Number(inputElementFrom.value)
    );

    outtElementTo.value =
      convertFromMeeter[selectedElementTo.value](curentMeters);
  });
}
