import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { BlogPostsComponent } from './blog-posts.component';
import { HttpClientModule } from '@angular/common/http';

describe('BlogPostsComponent', () => {
  let component: BlogPostsComponent;
  let fixture: ComponentFixture<BlogPostsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, HttpClientModule,],
      declarations: [ BlogPostsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
