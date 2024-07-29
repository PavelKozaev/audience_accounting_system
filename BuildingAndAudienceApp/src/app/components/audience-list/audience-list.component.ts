import { Component, inject } from '@angular/core';
import { IBuilding } from '../../interfaces/building';
import { HttpService } from '../../http.service';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IAudience } from '../../interfaces/audience';
@Component({
  selector: 'app-audience-list',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, RouterLink],
  templateUrl: './audience-list.component.html',
  styleUrl: './audience-list.component.css'
})
export class AudienceListComponent {
  router=inject(Router)
  audienceList:IAudience[]=[];
httpService=inject(HttpService);
toastr=inject(ToastrService);
displayedColumns: string[] = [
  'id',
  'buildingId',   
  'name', 
  'type', 
  'capacity',
  'floor',
  'number',
  'action'
];

ngOnInit(){
 this.getAudienceFromServer();
}

getAudienceFromServer(){
    this.httpService.getAudiences().subscribe(result=>{    
      this.audienceList=result;
      console.log(this.audienceList);
    })
  }

  edit(id:number){
    console.log(id);
    this.router.navigateByUrl("/audience/"+id);
  }

  delete(id:number){
    this.httpService.deleteAudience(id).subscribe(()=>{
      console.log("deleted");      
      this.getAudienceFromServer();
      this.audienceList=this.audienceList.filter(x=>x.id!=id);
      this.toastr.success("Record deleted successfully.");
    })
    
  }
}
