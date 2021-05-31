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

const Card = ({ cardData }:any) => {
  return (
    <div>
      {cardData.map((data:any) => (
        <CardItem
          key={data.name}
          name={data.name}
          description={data.description}
        />
      ))}
    </div>
  );
};
const CardItem = ({ name, description } :any) => {
  return (
    <div>
      <div>Name: {name}</div>
      <div>Description: {description}</div>
    </div>
  );
};

export default () => <Card cardData={data} />;
