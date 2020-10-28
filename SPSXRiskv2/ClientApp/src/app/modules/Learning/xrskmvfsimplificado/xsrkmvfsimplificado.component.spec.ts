import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { XSRKMVFSimplificadoComponent } from './xsrkmvfsimplificado.component';

describe('MVFSimplificadoComponent', () => {
  let component: XSRKMVFSimplificadoComponent;
  let fixture: ComponentFixture<XSRKMVFSimplificadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [XSRKMVFSimplificadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XSRKMVFSimplificadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
