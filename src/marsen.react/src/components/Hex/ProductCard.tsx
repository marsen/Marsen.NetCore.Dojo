import React from "react"
import { Card,Button } from "react-bootstrap";

export default function ProductCard({
    name,
    picture,
    description,
    price,
    cartItem,
    setCartItem
  }) {
    return (
      <Card key={name} style={{ width: "18rem" }}>
        <Card.Img variant="top" src={picture} />
        <Card.Body>
          <Card.Title>
            {name} ${price}NT
          </Card.Title>
          <Card.Text>{description}</Card.Text>
          <Button
            variant="primary"
            onClick={() =>
              setCartItem(
                cartItem.concat({
                  name,
                  description,
                  price
                })
              )
            }
          >
            Add To Cart
          </Button>
        </Card.Body>
      </Card>
    );
  }