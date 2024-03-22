function solve(input) {
  const allStudents = input.reduce((acc, row) => {
    const [nameInfo, gradeInfo, scoreInfo] = row.split(", ");
    const name = nameInfo.split("Student name: ")[1];
    const grade = Number(gradeInfo.split("Grade: ")[1]);
    const score = Number(
      scoreInfo.split("Graduated with an average score: ")[1]
    );

    if (score >= 3) {
      acc.push({
        name,
        grade: grade + 1,
        score: score,
      });
    }
    return acc;
  }, []);

  const dictionary = allStudents.reduce((acc, obj) => {
    const { grade } = obj;
    if (!acc[grade]) {
      acc[grade] = [];
    }
    acc[grade].push(obj);
    return acc;
  }, {});

  Object.entries(dictionary).forEach(([grade, students]) => {
    console.log(`${grade} Grade`);
    const numberOfStudents = students.length;
    let scoreSum = 0;
    const studentsNames = [];

    students.forEach((student) => {
      scoreSum += student.score;
      studentsNames.push(student.name)
    });
    console.log(`List of students: ${studentsNames.join(", ")}`)
    console.log(`Average annual score from last year: ${(scoreSum / numberOfStudents).toFixed(2)}`)
    console.log(" ");
  });
}

solve([
  "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
  "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
  "Student name: George, Grade: 8, Graduated with an average score: 2.83",
  "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
  "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
  "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
  "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
  "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
  "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
  "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
  "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
  "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00",
]);
