import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonApiService } from 'src/app/person-api.service';
import { IPerson } from 'src/app/Shared/models/person';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-show-person',
  templateUrl: './show-person.component.html',
  styleUrls: ['./show-person.component.Scss']
})
export class ShowPersonComponent implements OnInit {

  personList:any={}




  constructor(private service: PersonApiService) { }
  personData = new FormGroup({
    
    name : new FormControl("" ,[Validators.required]) ,
    age : new FormControl("" ,[Validators.required]) ,
    
     address:new FormControl({
      street:new FormControl("",[Validators.required]),
    city : new FormControl("" ,[Validators.required]) ,
    country : new FormControl("" ,[Validators.required]) ,
     } )
    
  })
  ngOnInit(): void { 

this.getPersons();
  
  }

 
    
  displayStyle = "none";
  displayStyle2 = "none";
  
  openPopup() {
    this.displayStyle = "block";
  }
  openPopup2() {
    this.displayStyle2 = "block";
  }
  closePopup() {
    this.displayStyle = "none";
  }
  closePopup2() {
    this.displayStyle2 = "none";
  }

 
  getPersons(){
    this.service.getPersonList().subscribe(
      (personList:any)=> {
        this.personList=personList.data ; 
        console.log(personList);
      },(error)=>{
        console.log(error);
      }
    )
  } 
  addPerson():void{ 
    
   
    
    this.service.addNewPerson(this.personList).subscribe(res=>{
      this.personList=res;
      this.getPersons();
      window.location.reload();
    })
  }
  updatePerson(data:any){ 
    const per={
      "id":0,
      "name":this.personData.value.name,
      "age":this.personData.value.age,
      "address": {
        "id": 0,
        "street":this.personData.value.address?.street,
        "city":this.personData.value.address?.city,
        "country": this.personData.value.address?.country
      }
    }
    
    this.service.updatePerson(data).subscribe(res=>{
      this.personList=res;
      this.getPersons();
      window.location.reload();
    })
  }
  
  onDeletePerson(){
    this.service.deletePerson(this.personList.id).subscribe(res=>{
      this.getPersons();

    })
  }
 


}
