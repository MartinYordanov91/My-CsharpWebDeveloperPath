function attachEventsListeners() {
  const days = document.getElementById("days");
  const hours = document.getElementById("hours");
  const minutes = document.getElementById("minutes");
  const seconds = document.getElementById("seconds");

  document.querySelector("#daysBtn").addEventListener("click", (e) => {
    days.value = days.value;
    hours.value = Number(days.value) * 24;
    minutes.value = Number(days.value) * 24 * 60;
    seconds.value = Number(days.value) * 24 * 60 * 60;
  });

  document.querySelector("#hoursBtn").addEventListener("click", (e) => {
    days.value = Number(hours.value) / 24;
    hours.value = Number(hours.value);
    minutes.value = Number(hours.value) * 60;
    seconds.value = Number(hours.value) * 60 * 60;
  });

  document.querySelector("#minutesBtn").addEventListener("click", (e) => {
    days.value = Number(minutes.value) / 60 / 24;
    hours.value = Number(minutes.value) / 60;
    minutes.value = Number(minutes.value);
    seconds.value = Number(minutes.value) * 60;
  });

  document.querySelector("#secondsBtn").addEventListener("click", (e) => {
    days.value = Number(seconds.value) / 60 / 60 / 24;
    hours.value = Number(seconds.value) / 60 / 60;
    minutes.value = Number(seconds.value) / 60;
    seconds.value = Number(seconds.value);
  });
}



// function attachEventsListeners() {

//     function convertTime(value, fromUnit, toUnit) {
//         const conversions = {
//             days: { hours: 24, minutes: 24 * 60, seconds: 24 * 60 * 60 },
//             hours: { days: 1 / 24, minutes: 60, seconds: 60 * 60 },
//             minutes: { days: 1 / (24 * 60), hours: 1 / 60, seconds: 60 },
//             seconds: { days: 1 / (24 * 60 * 60), hours: 1 / (60 * 60), minutes: 1 / 60 }
//         };
    
//         return value * conversions[fromUnit][toUnit];
//     }

    
//     const units = ["days", "hours", "minutes", "seconds"];

//     units.forEach(unit => {
//         const inputElement = document.getElementById(unit);

//         document.getElementById(`${unit}Btn`).addEventListener("click", () => {
//             const inputValue = parseFloat(inputElement.value);
//             units.forEach(toUnit => {
//                 if (toUnit !== unit) {
//                     document.getElementById(toUnit).value = convertTime(inputValue, unit, toUnit);
//                 }
//             });
//         });
//     });
// }
