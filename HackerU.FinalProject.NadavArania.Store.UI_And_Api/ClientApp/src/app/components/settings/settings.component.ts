import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IDiscardChangesInterface } from '../../guards/discard-changes-guard.service';
import { ProductService } from '../../services/product.service';
import { UserService } from '../../services/user.service';
import { ValidationService } from '../../services/validation.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit, IDiscardChangesInterface {

  view: boolean = false;
  sForm: boolean = false;
  profileReactiveForm: any;
  enteredValue: string = '';
  productReactiveForm: any;
  pForm: boolean = false;
  pfForm: boolean = false;
  paForm: boolean = false;
  currentProductId: number = 0;
  currentProfileId: number = 0;

  constructor(public service: UserService, public products: ProductService, public vali: ValidationService) { }

  //Shortcut For Form Values

  get email() { return this.profileReactiveForm.get('email'); }
  get password() { return this.profileReactiveForm.get('password'); }
  get phone() { return this.profileReactiveForm.get('phone'); }
  get city() { return this.profileReactiveForm.get('city'); }
  get address() { return this.profileReactiveForm.get('address'); }

  get type() { return this.productReactiveForm.get('type'); }
  get name() { return this.productReactiveForm.get('name'); }
  get price() { return this.productReactiveForm.get('price'); }
  get description() { return this.productReactiveForm.get('description'); }
  get image() { return this.productReactiveForm.get('image'); }
  get category() { return this.productReactiveForm.get('category'); }

  //Handle Discard Guard Navigation

  canExit(): boolean {
    if (this.sForm || this.pForm || this.pfForm || this.paForm) {
      return confirm("Are you sure you want to discard changes?");
    }
    else {
      return true;
    }
  }

  ngOnInit(): void {
    this.profileReactiveForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.pattern(this.vali.emailRegex)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(12), Validators.pattern(this.vali.passwordRegex)]),
      phone: new FormControl(null, [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
      city: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      address: new FormControl(null, [Validators.required, Validators.minLength(3)])
    });

    this.productReactiveForm = new FormGroup({
      type: new FormControl(null, [Validators.required]),
      name: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(150)]),
      price: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required, Validators.minLength(10)]),
      image: new FormControl(null, [Validators.required]),
      category: new FormControl(null, [Validators.required])
    })

    this.vali.alert = false;
    this.vali.changesFailed = false;
    this.vali.addFailed = false;
    this.vali.deleteFailed = false;

    this.service.fetchUsersFromDb();
  }

  //Handle Of Showing And Closing Orders Details

  showOrders(id: number) {
      this.view = true;
      this.service.fetchFullHistoryPerUser(id);
  }

  closeOrders() {
    this.view = false;
  }

  //Handle Profile Forms

  showForm(id: number) {
    this.currentProfileId = id;
    if (!this.sForm) {
      this.sForm = true;
      this.profileReactiveForm.setValue({
        email: this.service.loggedUser.email,
        password: '',
        phone: this.service.loggedUser.phone,
        city: this.service.loggedUser.city,
        address: this.service.loggedUser.address
      });
    }
    else {
      this.sForm = false;
    }
  }

  profileForm(u: any) {
    this.currentProfileId = u.id;
    if (!this.pfForm) {
      this.pfForm = true;
      this.profileReactiveForm.setValue({
        email: u.email,
        password: '',
        phone: u.phone,
        city: u.city,
        address: u.address
      });
    }
  }

  //Handle Editing Product Form
  productForm(p: any) {
    this.currentProductId = p.id;
    if (!this.pForm) {
      this.pForm = true;
      this.productReactiveForm.setValue({
        type: p.type,
        name: p.name,
        price: p.price,
        description: p.description,
        image: p.image,
        category: p.category
      });
    }
    else {
      this.currentProductId = 0;
      this.pForm = false;
    }
  }

  //Handle Submitting New Product To DB

  onSubmitProductAdd() {
    if (this.productReactiveForm.valid) {
      this.products.addProductToDB(this.type?.value, this.name?.value, this.price?.value, this.description?.value, this.image?.value, this.category?.value);
      this.paForm = false;
      this.vali.alert = true;
    }
    else {
      this.vali.addFailed = true;
    }
  }

  //Handle Adding Product Form

  addProductForm() {
    if (!this.paForm) {
      this.productReactiveForm.setValue({
        type: '',
        name: '',
        price: '',
        description: '',
        image: '',
        category: ''
      });
      this.paForm = true;
    }
    else {
      this.paForm = false;
    }
  }

  //Handle Closing Forms Edit

  closeEdit() {
    this.currentProfileId = 0;
    this.pfForm = false;
    this.pForm = false;
    this.paForm = false;
  }

  //Handles Submmiting Changes In Profile And Product

  onSubmitProfile() {
    this.service.editProfileDetails(this.currentProfileId, this.email?.value, this.password?.value, this.phone?.value, this.city?.value, this.address?.value);
    this.pfForm = false;
    this.sForm = false;
  }

  onSubmitProduct() {
    this.products.editProductDetails(this.currentProductId, this.type?.value, this.name?.value, this.price?.value, this.description?.value, this.image?.value, this.category?.value);
    this.pForm = false;
  }

  //Handle Deleting Product From Cart

  deleteFromCart(number: string) {
    this.products.deleteOrder(number);
    this.view = false;
  }

}
