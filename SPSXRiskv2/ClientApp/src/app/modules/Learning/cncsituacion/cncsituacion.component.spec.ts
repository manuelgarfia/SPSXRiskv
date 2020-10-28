import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CNCSituacionComponent } from './cncsituacion.component';

describe('CNCSituacionComponent', () => {
  let component: CNCSituacionComponent;
  let fixture: ComponentFixture<CNCSituacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CNCSituacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CNCSituacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
