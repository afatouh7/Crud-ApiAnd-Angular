import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPerson } from 'src/app/Shared/models/person';

@Injectable({
  providedIn: 'root'
})

export class PersonApiService {
  readonly personApi="https://localhost:44373/api";

  constructor(private http: HttpClient) { } 
 

getPersonList():Observable<any[]>{
  return this.http.get<any[]>(this.personApi +'/Person');
}

addNewPerson(data:any):Observable<any>{
  const per = {
    // id: Number(data.id),
    name: data.name,
  
    age: Number(data.age),
    street:data.street,
    city:data.city,
    country:data.country
    

  }
  return this.http.post(this.personApi +'/Person',per);
} 

updatePerson(data :any){
  return this.http.put(this.personApi + '/person/${id}',data);
}
deletePerson(id:number){
  return this.http.delete(this.personApi +'/person/${id}');
}
}
