function arePurfectNumber(number) {
  let sum = 0;
  for (let index = 1; index < number; index++) {
    number % index === 0 ? (sum += index) : "";
  }

  number === sum
  ?console.log("We have a perfect number!")
  :console.log("It's not so perfect.")
}

arePurfectNumber(6)
arePurfectNumber(28)
arePurfectNumber(1236498)