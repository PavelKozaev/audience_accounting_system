import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IBuilding } from './interfaces/building';
import { IAudience } from './interfaces/audience';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  apiUrlBuilding="https://localhost:7015"; 
  apiUrlAudience="https://localhost:7247"; 
  http=inject(HttpClient)
  constructor() { }

  getBuildings(){
    return this.http.get<IBuilding[]>(this.apiUrlBuilding+"/api/Building")
  }

  createBuilding(building:IBuilding) {
    return this.http.post(this.apiUrlBuilding+"/api/Building", building)
  }

  getBuilding(buildingId:number){
    return this.http.get<IBuilding>(this.apiUrlBuilding+"/api/Building/"+buildingId)
  }

  updateBuilding(buildingId:number, building:IBuilding){
    return this.http.put<IBuilding>(this.apiUrlBuilding+"/api/Building/"+buildingId, building)
  }

  deleteBuilding(buildingId:number){
    return this.http.delete(this.apiUrlBuilding+"/api/Building/"+buildingId)
  }  

  
  // Методы для работы с аудиториями
  getAudiences() {
    return this.http.get<IAudience[]>(`${this.apiUrlAudience}/api/Audience`);
  }

  createAudience(audience: IAudience) {
    return this.http.post(this.apiUrlAudience + "/api/Audience", audience);
  }

  getAudience(audienceId: number) {
    return this.http.get<IAudience>(`${this.apiUrlAudience}/api/Audience/${audienceId}`);
  }

  updateAudience(audienceId: number, audience: IAudience) {
    return this.http.put<IAudience>(`${this.apiUrlAudience}/api/Audience/${audienceId}`, audience);
  }

  deleteAudience(audienceId: number) {
    return this.http.delete(`${this.apiUrlAudience}/api/Audience/${audienceId}`);
  }
}
