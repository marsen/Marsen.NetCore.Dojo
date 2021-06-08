import React, { Dispatch, Fragment, SetStateAction } from "react";
import { Button, Card, CardGroup, Carousel } from "react-bootstrap";

import productData from "./data/food.json";

import "bootstrap/dist/css/bootstrap.min.css";

class CartItemProperty {
  constructor(name: string, description: string, price: number) {
    this.name = name;
    this.description = description;
    this.price = price;
  }
  name: string;
  description: string;
  price: number;
}

interface ProductCardProperty {
  name: string;
  picture: string;
  description: string;
  price: number;
  cartItem: CartItemProperty[];
  setCartItem: Dispatch<SetStateAction<never[]>>;
}

interface ProductProp {
  cartItem: CartItemProperty[];
  setCartItem: Dispatch<SetStateAction<never[]>>;
}

export function ProductCard(prop: ProductCardProperty) {
  return (
    <Card key={prop.name} style={{ width: "18rem" }}>
      <Card.Img variant="top" src={prop.picture} />
      <Card.Body>
        <Card.Title>
          {prop.name} ${prop.price}NT
        </Card.Title>
        <Card.Text>{prop.description}</Card.Text>
        <Button
          variant="primary"
          onClick={() =>
            prop.setCartItem(
              prop.cartItem.concat(
                new CartItemProperty(prop.name, prop.description, prop.price)
              )
            )
          }
        >
          Add To Cart
        </Button>
      </Card.Body>
    </Card>
  );
}

export function ProductCarousel() {
  return (
    <Carousel>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://images.unsplash.com/photo-1558981285-501cd9af9426?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60"
          alt="First slide"
        />
        <Carousel.Caption>
          <h3>First slide label</h3>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://images.unsplash.com/photo-1584464367415-2e7ff6482b54?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60"
          alt="Third slide"
        />

        <Carousel.Caption>
          <h3>Second slide label</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://images.unsplash.com/photo-1584473457493-17c4c24290c9?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=60"
          alt="Third slide"
        />

        <Carousel.Caption>
          <h3>Third slide label</h3>
          <p>
            Praesent commodo cursus magna, vel scelerisque nisl consectetur.
          </p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
}

export default function Product(prop: ProductProp) {
  return (
    <Fragment>
      <ProductCarousel />
      <div style={{ marginTop: 20 }}>
        <CardGroup>
          {productData.map((product) => (
            <ProductCard
              key={product.name}
              {...product}
              cartItem={prop.cartItem}
              setCartItem={prop.setCartItem}
            />
          ))}
        </CardGroup>
      </div>
    </Fragment>
  );
}
