import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GformsComponent } from './gforms.component';

describe('GformsComponent', () => {
  let component: GformsComponent;
  let fixture: ComponentFixture<GformsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GformsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GformsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
