function byTicket(day, age) {
  let result = undefined;
  if (0 <= age && age <= 18) {
    if (day === "Weekday") {
      result = "12$";
    } else if (day === "Weekend") {
      result = "15$";
    } else {
      result = "5$";
    }
  } else if (19 <= age && age <= 64) {
    if (day === "Weekday") {
      result = "18$";
    } else if (day === "Weekend") {
      result = "20$";
    } else {
      result = "12$";
    }
  } else if (65 <= age && age <= 122) {
    if (day === "Weekday") {
      result = "12$";
    } else if (day === "Weekend") {
      result = "15$";
    } else {
      result = "10$";
    }
  } else {
    result = "Error!";
  }
  console.log(result)
}

byTicket('Weekday', 42)
byTicket('Holiday', -12)
byTicket('Holiday', 15)