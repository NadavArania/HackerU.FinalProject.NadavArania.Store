import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  passwordRegex = new RegExp("^(?=.*[A-Za-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$");
  emailRegex = new RegExp("^[a-zA-Z0-9_.+]+(?<!^[0-9]*)@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
  alert: boolean = false;
  regFailed: boolean = false;
  logFailed: boolean = false;
  changesFailed: boolean = false;
  deleteFailed: boolean = false;
  addFailed: boolean = false;
  productAddTtitle = "Product Added!";
  productAddContent = "The product added successfully!";
  productAddFailedTitle = "Failed during adding product command!";
  productAddFailedContent = "There was error while trying adding product!";
  productDeleteTitle = "Product Removed";
  productDeleteContent = "The product deleted successfully!";
  productDeleteFailedTitle = "Failed during deleting product command!";
  productDeleteFailedContent = "There was error while trying adding product!";
  cartPurchasedCompleteTitle = "Purchased Completed!";
  cartPurchasedCompleteContent = "You order has been sent, please check if you got an email confirmation and reciet!";
  cartEmptyTitle = "Your cart is empty!";
  cartEmptyContent = "You can navigate our website and find what you need,So what are you waiting for? Start to shop!";
  emptyEmailFailed = "Email field cant be empty!";
  emailFormatFailed = "Email should be in correct format!";
  emptyPasswordFailed = "Password field cant be empty!";
  passwordFormatFailed = "Password should include at least 1 number and 1 symbol and to be 6 figuers long or more!";
  emptyPhoneFailed = "Phone field cant be empty!";
  phoneLengthFailed = "Phone should be 10 digits!";
  emptyCityFailed = "City field cant be empty!";
  cityLengthFailed = "City should have at least 3 chars!";
  emptyAddressFailed = "Address field cant be empty!";
  addressLengthFailed = "Address should have at least 3 chars!";
  emptyTypeFailed = "Type field cant be empty!";
  emptyNameFailed = "Name field cant be empty!";
  nameLengthFailed = "Name should have at least 15 chars!";
  emptyPriceFailed = "Price field cant be empty!";
  emptyDescriptionFailed = "Description field cant be empty!";
  descriptionMinLengthFailed = "Description should have at least 6 chars!";
  descriptionMaxLengthFailed = "Description should have at max 50 chars!";
  emptyImageFailed = "Image field cant be empty!";
  emptyCategoryFailed = "Category field cant be empty!";
  productAddedToCartTitle = "Product Added!";
  productAddedToCartContent = "Product Have Successfully added! If you want to go to cart press the button!";
  productInCartAlreadyTitle = "Product already inside cart!";
  productInCartAlreadyContent = "The product that you picked is already inside the cart! Go and buy it right now!";
  loginFailedTitle = "Failed during login command!";
  loginFailedContent = " One or more fields was wrong, please try again!";
  loginCompleteTitle = "Login Completed!";
  loginCompleteContent = "You are now able to purchases products from our store!";
  registerFailedTitle = "Failed during register command!";
  registerFailedContent = "One or more fields was wrong, please try again!";
  registerCompleteTitle = "Registration Completed!";
  registerCompleteContent = "You are now able to login and start your shopping!";
  loggedAlreadyTitle = "You are logged already";
  loggedAlreadyContent = "What are you looking for is not in this page!";
  registerAlreadyTitle = "You are registered already";

  constructor() { }
}
