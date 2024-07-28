import { Component, inject } from '@angular/core';
import { IBuilding } from '../../interfaces/building';
import { HttpService } from '../../http.service';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-building-list',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, RouterLink],
  templateUrl: './building-list.component.html',
  styleUrl: './building-list.component.css'
})
export class BuildingListComponent {
  router=inject(Router)
buildingList:IBuilding[]=[];
httpService=inject(HttpService);
toastr=inject(ToastrService);
displayedColumns: string[] = [
  'id', 
  'name', 
  'address', 
  'floors',
  'action'
];

ngOnInit(){
 this.getBuildingFromServer();
}

  getBuildingFromServer(){
    this.httpService.getBuildings().subscribe(result=>{    
      this.buildingList=result;
      console.log(this.buildingList);
    })
  }

  edit(id:number){
    console.log(id);
    this.router.navigateByUrl("/building/"+id);
  }

  delete(id:number){
    this.httpService.deleteBuilding(id).subscribe(()=>{
      console.log("deleted");      
      this.getBuildingFromServer();
      this.buildingList=this.buildingList.filter(x=>x.id!=id);
      this.toastr.success("Record deleted successfully.");
    })
    
  }
}
