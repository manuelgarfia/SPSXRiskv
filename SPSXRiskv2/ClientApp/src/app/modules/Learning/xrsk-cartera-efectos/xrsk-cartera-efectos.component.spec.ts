import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { XrskCarteraEfectosComponent } from './xrsk-cartera-efectos.component';

describe('XrskCarteraEfectosComponent', () => {
  let component: XrskCarteraEfectosComponent;
  let fixture: ComponentFixture<XrskCarteraEfectosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ XrskCarteraEfectosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XrskCarteraEfectosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
