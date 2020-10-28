import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { XriskDesgloseComponent } from './xrisk-desglose.component';

describe('XriskDesgloseComponent', () => {
  let component: XriskDesgloseComponent;
  let fixture: ComponentFixture<XriskDesgloseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ XriskDesgloseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XriskDesgloseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
