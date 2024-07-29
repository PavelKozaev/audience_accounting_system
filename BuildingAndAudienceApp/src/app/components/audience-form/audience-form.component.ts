import { Component, inject } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import { HttpService } from '../../http.service';
import { IBuilding } from '../../interfaces/building';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IAudience } from '../../interfaces/audience';
@Component({
  selector: 'app-audience-form',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './audience-form.component.html',
  styleUrl: './audience-form.component.css'
})
export class AudienceFormComponent {
formBuilder=inject(FormBuilder);
httpService=inject(HttpService);
router=inject(Router);
route=inject(ActivatedRoute);
toastr=inject(ToastrService);

audienceForm=this.formBuilder.group({
  buildingId:[1,[Validators.required]],
  name:['',[Validators.required]],
  type:[1,[Validators.required]],
  capacity:[1,[Validators.required]],
  floor:[0,[Validators.required]],
  number:[8,[Validators.required]],
});

audienceId!:number;
isEdit=false;

ngOnInit(){
  this.audienceId=this.route.snapshot.params['id'];
  if(this.audienceId) {
    this.isEdit=true;
    this.httpService.getAudience(this.audienceId).subscribe(result=>{
      console.log(result);
      this.audienceForm.patchValue(result);
    });
  }
}

save(){
  console.log(this.audienceForm.value)
  const audience: IAudience = {
    buildingId:this.audienceForm.value.buildingId!,
    name:this.audienceForm.value.name!,
    type:this.audienceForm.value.type!,
    capacity:this.audienceForm.value.capacity!,
    floor:this.audienceForm.value.floor!,
    number:this.audienceForm.value.number!
  }

  if(this.isEdit){
    this.httpService.updateAudience(this.audienceId, audience).subscribe(()=>{
      console.log("success");
      this.toastr.success("Record updated successfully.");
      this.router.navigateByUrl("/audience-list");
    });
  }else{
    this.httpService.createAudience(audience).subscribe(()=>{
      console.log("success");
      this.toastr.success("Record added successfully.");
      this.router.navigateByUrl("/audience-list");
    });
  }  
}
}
