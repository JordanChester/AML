import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Media} from "../_models/Media";
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, ɵValue} from '@angular/forms';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {StorageService} from "../_services/storage.service";
import {MediaService} from "../_services/media.service";

@Component({
  selector: 'app-order-media',
  templateUrl: './order-media.component.html',
  styleUrl: './order-media.component.css'
})

export class OrderMediaComponent implements OnInit{
  mediaData: any;
  media: Media = new Media();
  readonly range = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });
  userId: any
  startDate: Date = new Date();
  endDate: Date = new Date();

  constructor(private router: Router,
              private route: ActivatedRoute,
              private storageService: StorageService,
              private mediaService: MediaService) {
  }
  ngOnInit() {
    this.mediaData = this.route.snapshot.paramMap.get('media');
    if (!this.mediaData) {
      this.router.navigate(['']);
    }
    this.media = <Media>JSON.parse(this.mediaData);
    console.log(this.media.price);
  }

  confirm(start: ɵValue<FormControl<Date | null>> | undefined, end: ɵValue<FormControl<Date | null>> | undefined): void {
    console.log(start, end);
    this.startDate = <Date>start
    this.endDate = <Date>end
    this.userId = this.storageService.getUser().id

    this.mediaService.borrowMedia(this.userId, this.media.id, this.startDate, this.endDate).subscribe({
      next: data => {
        if (data){
          this.router.navigate(['account']);
        }
      },
      error: err => {
        console.log(err.error.message);
      }
    })
  }
}
