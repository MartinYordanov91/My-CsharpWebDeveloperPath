function isLeepYear(year) {
  if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
    console.log("yes");
  } else {
    console.log("no");
  }
}

isLeepYear(1984)
isLeepYear(2003)
isLeepYear(4)
isLeepYear(2024)