import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterNewsComponent } from './alter-news.component';

describe('AlterNewsComponent', () => {
  let component: AlterNewsComponent;
  let fixture: ComponentFixture<AlterNewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlterNewsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlterNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
