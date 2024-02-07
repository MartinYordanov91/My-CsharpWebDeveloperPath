function vacantionCalculate(peopleCount, typePeople, dayOfWeek) {
  const curentPrice = {
    Students: {
      Friday: 8.45,
      Saturday: 9.8,
      Sunday: 10.46,
    },

    Business: {
      Friday: 10.9,
      Saturday: 15.6,
      Sunday: 16,
    },

    Regular: {
      Friday: 15,
      Saturday: 20,
      Sunday: 22.5,
    },
  };

  let totalPrice = curentPrice[typePeople][dayOfWeek] * peopleCount;

  if (typePeople === "Students" && peopleCount >= 30) {
    totalPrice *= 0.85;
  }

  if (typePeople === "Business" && peopleCount >= 100) {
    totalPrice -= curentPrice[typePeople][dayOfWeek] * 10;
  }

  if (typePeople === "Regular" && peopleCount >= 10 && peopleCount <= 20) {
    totalPrice *= 0.95;
  }

  console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

vacantionCalculate(30, "Students", "Sunday");
vacantionCalculate(40, "Regular", "Saturday");
