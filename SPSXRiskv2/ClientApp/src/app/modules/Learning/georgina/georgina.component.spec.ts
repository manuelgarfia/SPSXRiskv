import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GeorginaComponent } from './georgina.component';

describe('GeorginaComponent', () => {
  let component: GeorginaComponent;
  let fixture: ComponentFixture<GeorginaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GeorginaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GeorginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
