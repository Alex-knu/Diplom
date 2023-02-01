import { Component, OnInit } from '@angular/core';
import { Application } from 'src/app/shared/models/application.model';

@Component({
  selector: 'app-application-table',
  templateUrl: './application-table.component.html',
  styleUrls: ['./application-table.component.scss'],
  styles: [
    `
        :host ::ng-deep .p-dialog .product-image {
            width: 150px;
            margin: 0 auto 2rem auto;
            display: block;
        }
    `
  ],
})
export class ApplicationTableComponent implements OnInit {
  applicationDialog: boolean;

  applications: Application[];

  application: Application;

  selectedApplications: Application[];

  submitted: boolean;

  statuses: any[];

  constructor() { }

  ngOnInit(): void {
  }

  openNew() {
    //this.application = new Application();
    this.submitted = false;
    this.applicationDialog = true;
  }

  deleteSelectedProducts() {
    // this.confirmationService.confirm({
    //     message: 'Are you sure you want to delete the selected products?',
    //     header: 'Confirm',
    //     icon: 'pi pi-exclamation-triangle',
    //     accept: () => {
    //         this.products = this.products.filter(val => !this.selectedProducts.includes(val));
    //         this.selectedProducts = null;
    //         this.messageService.add({severity:'success', summary: 'Successful', detail: 'Products Deleted', life: 3000});
    //     }
    // });
  }

  editProduct(application: Application) {
    //this.application = {...application};
    this.applicationDialog = true;
  }

  deleteProduct(application: Application) {
    // this.confirmationService.confirm({
    //     message: 'Are you sure you want to delete ' + product.name + '?',
    //     header: 'Confirm',
    //     icon: 'pi pi-exclamation-triangle',
    //     accept: () => {
    //         this.products = this.products.filter(val => val.id !== product.id);
    //         this.product = {};
    //         this.messageService.add({severity:'success', summary: 'Successful', detail: 'Product Deleted', life: 3000});
    //     }
    // });
  }

  hideDialog() {
    //this.productDialog = false;
    this.submitted = false;
  }

  saveProduct() {
    this.submitted = true;

    // if (this.product.name.trim()) {
    //     if (this.product.id) {
    //         this.products[this.findIndexById(this.product.id)] = this.product;
    //         this.messageService.add({severity:'success', summary: 'Successful', detail: 'Product Updated', life: 3000});
    //     }
    //     else {
    //         this.product.id = this.createId();
    //         this.product.image = 'product-placeholder.svg';
    //         this.products.push(this.product);
    //         this.messageService.add({severity:'success', summary: 'Successful', detail: 'Product Created', life: 3000});
    //     }

    //     this.products = [...this.products];
    //     this.productDialog = false;
    //     this.product = {};
    // }
  }

  findIndexById(id: string): number {
    let index = -1;
    for (let i = 0; i < this.applications.length; i++) {
        // if (this.applications[i].id === id) {
        //     index = i;
        //     break;
        // }
    }

    return index;
  }

  createId(): string {
    let id = '';
    var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for ( var i = 0; i < 5; i++ ) {
        id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }
}
