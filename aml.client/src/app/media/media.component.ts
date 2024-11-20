import {Component, Input, OnInit} from '@angular/core';
import {Media} from "../Models/Media";

@Component({
  selector: 'app-media',
  templateUrl: './media.component.html',
  styleUrl: './media.component.css'
})
export class MediaComponent implements OnInit{
  @Input() media! : Media

  ngOnInit(): void {
    console.log(this.media);
  }
}
