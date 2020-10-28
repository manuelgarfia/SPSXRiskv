import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SecurityObjectComponent } from './security-object.component';

describe('SecurityObjectComponent', () => {
  let component: SecurityObjectComponent;
  let fixture: ComponentFixture<SecurityObjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SecurityObjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SecurityObjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
