function makeAverageHigherFive(number) {
  function sumDigits(num) {
    let tex = num.toString();
    let sum = 0;
    for (let index = 0; index < tex.length; index++) {
      sum += Number(tex[index]);
    }

    return sum;
  }

  while (sumDigits(number) / number.toString().length < 5) {
    number+='9'
  }

  console.log(number)
}


makeAverageHigherFive(101)
makeAverageHigherFive(5835)