import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IBuilding } from './interfaces/building';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  apiUrl="https://localhost:7015";  
  http=inject(HttpClient)
  constructor() { }

  getBuildings(){
    return this.http.get<IBuilding[]>(this.apiUrl+"/api/Building")
  }

  createBuilding(building:IBuilding) {
    return this.http.post(this.apiUrl+"/api/Building", building)
  }

  getBuilding(buildingId:number){
    return this.http.get<IBuilding>(this.apiUrl+"/api/Building/"+buildingId)
  }

  updateBuilding(buildingId:number, building:IBuilding){
    return this.http.put<IBuilding>(this.apiUrl+"/api/Building/"+buildingId, building)
  }

  deleteBuilding(buildingId:number){
    return this.http.delete(this.apiUrl+"/api/Building/"+buildingId)
  }  
}
