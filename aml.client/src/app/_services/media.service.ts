import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {MediaSearchRequest} from "../_DTOs/MediaSearchRequest";
import {Media} from "../_models/Media";
import {BorrowMediaRequest} from "../_DTOs/BorrowMediaRequest";

const MEDIA_API = 'http://localhost:7033/api/media/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})
  export class MediaService {
  constructor(private http: HttpClient) { }

  searchMedia(query: string | undefined): Observable<Media[]> {
    const request: MediaSearchRequest = {
      search: query,
    }

    return this.http.post<Media[]>(
      MEDIA_API + 'search-media',
      request,
      httpOptions
    );
  }

  borrowMedia(userId: number, mediaId: number, start: Date, end: Date): Observable<boolean> {
    const request: BorrowMediaRequest = {
      userId: userId,
      mediaId: mediaId,
      start: start,
      end: end,
    }

    return this.http.post<boolean>(
      MEDIA_API + 'borrow-media',
      request,
      httpOptions
    )
  }
}
