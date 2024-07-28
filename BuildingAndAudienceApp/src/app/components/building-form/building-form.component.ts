import { Component, inject } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import { HttpService } from '../../http.service';
import { IBuilding } from '../../interfaces/building';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-building-form',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './building-form.component.html',
  styleUrl: './building-form.component.css'
})
export class BuildingFormComponent {
formBuilder=inject(FormBuilder);
httpService=inject(HttpService);
router=inject(Router);
route=inject(ActivatedRoute);
toastr=inject(ToastrService);
buildingForm=this.formBuilder.group({
  name:['',[Validators.required]],
  address:['',[Validators.required]],
  floors:[0,[Validators.required]]
});

buildingId!:number;
isEdit=false;

ngOnInit(){
  this.buildingId=this.route.snapshot.params['id'];
  if(this.buildingId) {
    this.isEdit=true;
    this.httpService.getBuilding(this.buildingId).subscribe(result=>{
      console.log(result);
      this.buildingForm.patchValue(result);
    });
  }
}

save(){
  console.log(this.buildingForm.value)
  const building: IBuilding = {
    name:this.buildingForm.value.name!,
    address:this.buildingForm.value.address!,
    floors:this.buildingForm.value.floors!
  }

  if(this.isEdit){
    this.httpService.updateBuilding(this.buildingId, building).subscribe(()=>{
      console.log("success");
      this.toastr.success("Record updated successfully.");
      this.router.navigateByUrl("/building-list");
    });
  }else{
    this.httpService.createBuilding(building).subscribe(()=>{
      console.log("success");
      this.toastr.success("Record added successfully.");
      this.router.navigateByUrl("/building-list");
    });
  }  
}
}
