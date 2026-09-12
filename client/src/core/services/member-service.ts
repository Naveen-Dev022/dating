import { HttpClient } from '@angular/common/http';
import { inject, Service } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member, Photo } from '../../types/member';
import { AccountService } from './account-service';

@Service()
export class MemberService {
  private http = inject(HttpClient);
  private accountService = inject(AccountService);
  private baseUrl = environment.apiUrl;

  getMembers() {
    return this.http.get<Member[]>(this.baseUrl + 'members');
  }

  getMember(id: string) {
    return this.http.get<Member>(this.baseUrl + 'members/' + id);
  }
  getMemberPhotos(id: string) {
    return this.http.get<Photo[]>(this.baseUrl + 'members/' + id + '/photos');
  }
}
