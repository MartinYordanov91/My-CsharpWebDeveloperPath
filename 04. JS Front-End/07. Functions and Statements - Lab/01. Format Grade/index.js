function formatGrade(grade) {
  if (grade < 3) {
    console.log(`Fail (2)`);
    return;
  }

  let definitionGrade = "";

  grade < 3.5
    ? (definitionGrade = "Poor")
    : grade < 4.5
    ? (definitionGrade = "Good")
    : grade < 5.5
    ? (definitionGrade = "Very good")
    : (definitionGrade = "Excellent");

  console.log(`${definitionGrade} (${grade.toFixed(2)})`);
}
