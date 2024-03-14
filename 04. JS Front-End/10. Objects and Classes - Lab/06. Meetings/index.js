function meetingMangers(meeting) {
  const sucsess = meeting.reduce((acc, curent) => {
    const [day, customer] = curent.split(" ");
    if (acc[day]) {
      console.log(`Conflict on ${day}!`);
    } else {
      acc[day] = customer;
      console.log(`Scheduled for ${day}`);
    }

    return acc;
  }, {});

  Object.entries(sucsess).forEach(([key, value]) => {
    console.log(`${key} -> ${value}`);
  });
}

meetingMangers([
  "Monday Peter",
  "Wednesday Bill",
  "Monday Tim",
  "Friday Tim"
]);

meetingMangers([
  "Friday Bob",
  "Saturday Ted",
  "Monday Bill",
  "Monday John",
  "Wednesday George",
]);
