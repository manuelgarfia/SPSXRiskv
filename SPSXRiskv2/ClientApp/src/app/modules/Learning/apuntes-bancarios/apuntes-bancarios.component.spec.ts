import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApuntesBancariosComponent } from './apuntes-bancarios.component';

describe('ApuntesBancariosComponent', () => {
  let component: ApuntesBancariosComponent;
  let fixture: ComponentFixture<ApuntesBancariosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApuntesBancariosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApuntesBancariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
