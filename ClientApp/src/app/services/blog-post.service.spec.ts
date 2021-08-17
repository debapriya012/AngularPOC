import { TestBed, inject, async } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { BlogPostService } from './blog-post.service';



describe('BlogPostService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientTestingModule,
    ],
    providers: [
      BlogPostService,
    ],
  }));

  //   it('should be created', () => {
  //     const service: BlogPostService = TestBed.get(BlogPostService);
  //     expect(service).toBeTruthy();
  //   });
  // });
  it('should get users',async(inject([HttpTestingController, BlogPostService],
    (httpMock: HttpTestingController, apiService: BlogPostService) => {
      expect(apiService).toBeTruthy();
    })));
});
