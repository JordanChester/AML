import {Component, Input, OnInit} from '@angular/core';
import {Media} from "../_models/Media";
import {MediaService} from "../_services/media.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-media',
  templateUrl: './media.component.html',
  styleUrl: './media.component.css'
})
export class MediaComponent implements OnInit{
  @Input() media! : Media

  constructor(private mediaService: MediaService, private router: Router){}

  ngOnInit(): void {
    console.log(this.media);
  }

  order(): void{
    this.router.navigate(['order', { media: JSON.stringify(this.media)}]);
  }
}
