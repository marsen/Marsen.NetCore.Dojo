import React from "react";

const data = [
  {
    name: "foo",
    description: "Im foooooooo..."
  },
  {
    name: "bar",
    description: "Im barrrr......"
  }
];
const Card = ({ cardData }) => {
  // return cardData.map(data => (
  //   <div key={data.name}>
  //     <div>Name: {data.name}</div>
  //     <div>Description: {data.description}</div>
  //   </div>
  // ));
  return (
    <div>
      {cardData.map(data => (
        <CardItem
          key={data.name}
          name={data.name}
          description={data.description}
        />
      ))}
    </div>
  );
};
const CardItem = ({ name, description }) => {
  return (
    <div>
      <div>Name: {name}</div>
      <div>Description: {description}</div>
    </div>
  );
};
export default () => <Card cardData={data} />;

// function an() {
//   return Card({
//     cardData: data
//   })
// }
