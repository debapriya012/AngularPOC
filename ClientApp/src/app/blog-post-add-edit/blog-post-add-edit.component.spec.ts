import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { BlogPostAddEditComponent } from './blog-post-add-edit.component';
import { HttpClientModule } from '@angular/common/http';
import{ReactiveFormsModule} from '@angular/forms'

describe('BlogPostAddEditComponent', () => {
  let component: BlogPostAddEditComponent;
  let fixture: ComponentFixture<BlogPostAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, HttpClientModule,ReactiveFormsModule],
      declarations: [ BlogPostAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogPostAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
