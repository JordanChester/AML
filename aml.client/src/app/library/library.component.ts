import {Component, Input, input, OnInit} from '@angular/core';
import {Media} from "../_models/Media";
import {MediaService} from "../_services/media.service";
import {StorageService} from "../_services/storage.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrl: './library.component.css'
})
export class LibraryComponent implements OnInit{

  constructor(private mediaService: MediaService, private route: ActivatedRoute) {
  }

  @Input() search: string | undefined = '';
  mediaList: Media[] = [];
  ngOnInit(): void {
    this.search = this.route.snapshot.paramMap.get('search')?.valueOf()
    console.log(this.search);

    this.mediaList = [{
      name: 'name',
      price: 0,
      isAvailable: true,
      mediaType: 'Video',
      description: 'test description',
    },
      {
        name: 'name2',
        price: 0,
        isAvailable: true,
        mediaType: 'Video',
        description: 'test description2',
      }];

    this.mediaService.searchMedia(this.search).subscribe({
      next: data => {
        this.mediaList = data;
      }
    })
  }
}
